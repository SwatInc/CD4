using CD4.AstmInterface.Model;
using CD4.DataLibrary.DataAccess;
using CD4.ResultsInterface.Common.Models;
using CD4.ResultsInterface.Common.Services;
using CSScriptLib;
using Newtonsoft.Json;
using slf4net;
using SwatInc.Lis.Lis01A2.Interfaces;
using SwatInc.Lis.Lis01A2.Services;
using SwatInc.Lis.Lis02A2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CD4.AstmInterface.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        dynamic _script;
        private bool _isScriptLoaded;
        private readonly IExportService exportService;
        private readonly ILogger logger;
        private readonly IScriptDataAccess _scriptDataAccess;
        private List<InterfaceResultsModel> interfaceResults;
        private InterfaceResultsModel tempResults;

        private ILis01A2Connection lowLevelConnection;
        private ILisConnection lisConnection;
        private LISParser lisParser;

        private EventHandler<List<InterfaceResultsModel>> ResultsReadyForExport;
        private event EventHandler Initialize;
        private event EventHandler<InterfaceResultsModel> OnRequireInterpretation;

        public MainViewModel(IScriptDataAccess scriptDataAccess)
        {
            this.logger = LoggerFactory.GetLogger(typeof(MainViewModel));
            this._scriptDataAccess = scriptDataAccess;
            Settings = new Model.Settings();
            interfaceResults = new List<InterfaceResultsModel>();
            exportService = new ExportService();
            logger.Info("Application startup... loaded settings");

            Initialize += RunInitalze;
            ResultsReadyForExport += ExportResults;
            OnRequireInterpretation += MainViewModel_OnRequireInterpretation;

            //invoke events
            Initialize?.Invoke(this, EventArgs.Empty);

        }

        private void MainViewModel_OnRequireInterpretation(object sender, InterfaceResultsModel e)
        {
            if (e is null) return;
            if (e.Measurements is null) return;

            var testCodeIndex = 0;
            var resultIndex = 1;
            var unitIndex = 2;
            foreach (var item in e.Measurements)
            {
                logger.Info($"Running interpretation for {item.TestCode} with result: {item.MeasurementValue} {item.Unit}");
                var resultArray = ((string)_script.GetInterpretation(item)).Split('|');
                var testCode = resultArray[testCodeIndex];
                var result = resultArray[resultIndex];
                var unit = resultArray[unitIndex];

                logger.Info($"Interpretation: Test Code: {testCode} Result: {result} {unit}");

                var tempInterpretations = new InterfaceResultsModel()
                {
                    SampleId = e.SampleId,
                    Measurements = new List<MeasurementValues>()
                    {
                        new MeasurementValues(){TestCode = testCode, MeasurementValue = result, Unit = unit}
                    },
                };

                tempInterpretations.InstrumentId.InstrumentCode = Settings.AnalyserName;

                var tempInterpretationResults = new List<InterfaceResultsModel>() { tempInterpretations };
                ResultsReadyForExport?.Invoke(this, tempInterpretationResults);
            }

        }

        private async void RunInitalze(object sender, EventArgs e)
        {
            await LoadAndInitializeScript();
            InitializeAstm();
        }

        private async Task LoadAndInitializeScript()
        {
            logger.Info("Trying to load analyser specific scripts");

            try
            {
                var script = await _scriptDataAccess.LoadScriptByName(Settings.AnalyserName);
                if (string.IsNullOrEmpty(script))
                {
                    logger.Info($"Failed to load the script. Script name: {Settings.AnalyserName}. Please make sure that a script exists with the name.");
                    _isScriptLoaded = false;
                    return;
                }
                logger.Info("Script fetched successfully. Trying to initialize scripting engine.");


                //load script to execution engine
              _script = CSScript.Evaluator.LoadCode(script);


                //check the script
                if (_script.IsScriptLoaded())
                {
                    _isScriptLoaded = true;
                    logger.Info($"Script Loaded Successfully. Script name: {Settings.AnalyserName}");
                }
            }
            catch (Exception ex)
            {
                logger.Info($"Failed to initialize scripting engine. {ex.Message}");
            }
        }

        /// <summary>
        /// Event handler for ResultsReadyForExport
        /// </summary>
        private async void ExportResults(object sender, List<InterfaceResultsModel> e)
        {
            try
            {
                logger.Debug(JsonConvert.SerializeObject(e));
                await exportService.ExportToUploader(e, Settings.ExportBasepath, Settings.Extension, Settings.ControlExtension);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void InitializeAstm()
        {
            switch (Settings.ConnectionMode)
            {
                case ConnectionMode.Ethernet:
                    var isPortValid = ushort.TryParse(Settings.Port.ToString(), out var uShortPort);
                    if (!isPortValid) { logger.Error($"Invalid port defined: {Settings.Port}. Max value allowed for port is 65535"); return; }

                    lowLevelConnection = new Lis01A02TCPConnection(Settings.IpAddress, uShortPort);
                    lisConnection = new Lis01A2Connection(lowLevelConnection);
                    Connect();

                    break;
                case ConnectionMode.Serial:
                    lowLevelConnection = new Lis01A02RS232Connection(Settings.SerialPort);
                    lisConnection = new Lis01A2Connection(lowLevelConnection);
                    Connect();

                    break;
                default:
                    break;
            }
        }

        private void Connect()
        {
            lisParser = new LISParser(lisConnection);

            lisParser.OnSendProgress += LISParser_OnSendProgress; //Send data progress will trigger this event
            lisParser.OnReceivedRecord += LISParser_OnReceivedRecord; //incoming LIS frames will trigger this event
            try
            {
                lisParser.Connection.Connect();
            }
            catch (Exception ex)
            {
                logger.Error($"Error connecting: {ex.Message}");
                MessageBox.Show(ex.Message);
            }
        }

        private void LISParser_OnReceivedRecord(object Sender, ReceiveRecordEventArgs e)
        {
            switch (e.RecordType)
            {
                case LisRecordType.Header:
                    //var header = (HeaderRecord)e.ReceivedRecord;

                    break;
                case LisRecordType.Patient:
                    var patient = (PatientRecord)e.ReceivedRecord;

                    break;
                case LisRecordType.Order:
                    var order = (OrderRecord)e.ReceivedRecord;

                    //check whether there is a temp results data
                    if (tempResults != null) { interfaceResults.Add(tempResults); }

                    tempResults = new InterfaceResultsModel()
                    {
                        SampleId = order.SpecimenID,
                        Measurements = new List<MeasurementValues>()
                    };

                    break;
                case LisRecordType.Result:
                    var result = (ResultRecord)e.ReceivedRecord;
                    var testIds = result.UniversalTestID.TestID.Split('^');

                    string testCode = null;
                    if (testIds.Length == 4) { testCode = testIds[3]; }

                    tempResults.Measurements.Add(new MeasurementValues()
                    {
                        TestCode = testCode,
                        MeasurementValue = result.Data,
                        Unit = result.Units,
                    });

                    //Analyser name
                    tempResults.InstrumentId.InstrumentCode = Settings.AnalyserName;
                    //completed date and time
                    if (result.TestCompletedDateTime.HasValue)
                    {
                        tempResults.CompletedDateTime = result.TestCompletedDateTime
                            .Value.ToString("yyyyMMddHHmmssfff");
                    }

                    OnRequireInterpretation?.Invoke(this, tempResults);

                    break;
                case LisRecordType.Comment:
                    break;
                case LisRecordType.Query:
                    var query = (QueryRecord)e.ReceivedRecord;
                    break;
                case LisRecordType.Terminator:
                    //add any temp results
                    if (tempResults != null)
                    {
                        interfaceResults.Add(tempResults);
                    }
                    //export the results
                    Debug.WriteLine(JsonConvert.SerializeObject(interfaceResults, Formatting.Indented));

                    ResultsReadyForExport?.Invoke(this, interfaceResults);
                    interfaceResults.Clear();
                    //set temp results data to null
                    tempResults = null;
                    break;
                case LisRecordType.Scientific:
                    break;
                case LisRecordType.Information:
                    break;
                default:
                    break;
            }
        }

        private void LISParser_OnSendProgress(object sender, SendProgressEventArgs e)
        {
            Debug.WriteLine("Send Progress: " + e.Progress);
        }

        public Model.Settings Settings { get; set; }

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private ILisConnection LoadAssembly(string assemblyPath)
        {
            try
            {
                string assembly = Path.GetFullPath(assemblyPath);
                Assembly ptrAssembly = Assembly.LoadFile(assembly);
                foreach (Type item in ptrAssembly.GetTypes())
                {
                    if (!item.IsClass) continue;
                    if (item.GetInterfaces().Contains(typeof(ILisConnection)))
                    {
                        return (ILisConnection)Activator.CreateInstance(item, new Lis01A02RS232Connection(Settings.SerialPort));
                    }
                }

                throw new Exception("Invalid driver file, entrypoint not found!");

            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to load the driver.\n{ex.Message}");
            }

        }
    }
}
