using CD4.AstmInterface.Model;
using CD4.ResultsInterface.Common.Models;
using CD4.ResultsInterface.Common.Services;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
using System.Windows.Forms;

namespace CD4.AstmInterface.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IExportService exportService;
        private readonly ILogger<MainViewModel> logger;
        private List<InterfaceResultsModel> interfaceResults;
        private InterfaceResultsModel tempResults;

        private ILis01A2Connection lowLevelConnection;
        private ILisConnection lisConnection;
        private LISParser lisParser;

        private EventHandler<List<InterfaceResultsModel>> ResultsReadyForExport;
        public MainViewModel(ILogger<MainViewModel> logger)
        {
            this.logger = logger;
            Settings = new Settings();
            interfaceResults = new List<InterfaceResultsModel>();
            exportService = new ExportService();
            logger.LogInformation("Application startup... loaded settings");

            InitializeAstm();

            ResultsReadyForExport += ExportResults;
        }

        /// <summary>
        /// Event handler for ResultsReadyForExport
        /// </summary>
        private async void ExportResults(object sender, List<InterfaceResultsModel> e)
        {
            try
            {
                await exportService.ExportToUploader(interfaceResults, Settings.ExportBasepath, Settings.Extension, Settings.ControlExtension);
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
                    if (!isPortValid) { logger.LogError($"Invalid port defined: {Settings.Port}. Max value allowed for port is 65535"); return; }

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
                logger.LogError($"Error connecting: {ex.Message}");
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
                    if (testIds.Length == 4){testCode = testIds[3]; }

                    tempResults.Measurements.Add(new MeasurementValues()
                    {
                        TestCode = testCode,
                        MeasurementValue = result.Data,
                        Unit = result.Units,
                    });
                    //Analyser name
                    tempResults.InstrumentId.InstrumentCode = "EI-01";
                    //completed date and time
                    if (result.TestCompletedDateTime.HasValue)
                    {
                        tempResults.CompletedDateTime = result.TestCompletedDateTime
                            .Value.ToString("yyyyMMddHHmmssfff");
                    }

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

        public Settings Settings { get; set; }

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
