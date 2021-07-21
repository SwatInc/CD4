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
        private bool _processingIncomingOrders;
        private readonly IExportService _exportService;
        private readonly ILogger _logger;
        private readonly IScriptDataAccess _scriptDataAccess;
        private Timer _checkIncomingOrders;
        private List<InterfaceResultsModel> _interfaceResults;
        private InterfaceResultsModel _tempResults;
        private List<OrdersDownloadModel> _ordersBuffer;

        private ILis01A2Connection _lowLevelConnection;
        private ILisConnection _lisConnection;
        private LISParser _lisParser;

        private EventHandler<List<InterfaceResultsModel>> ResultsReadyForExport;
        private event EventHandler<QueryRecord> OnQueryReceived;
        private event EventHandler Initialize;
        private event EventHandler InitializeOrderTransmission;
        private event EventHandler<InterfaceResultsModel> OnRequireInterpretation;

        public MainViewModel(IScriptDataAccess scriptDataAccess, IExportService exportService)
        {
            _logger = LoggerFactory.GetLogger(typeof(MainViewModel));
            _processingIncomingOrders = false;
            _scriptDataAccess = scriptDataAccess;
            Settings = new Model.Settings();
            _interfaceResults = new List<InterfaceResultsModel>();
            _exportService = exportService;
            _ordersBuffer = new List<OrdersDownloadModel>();
            _logger.Info("Application startup... loaded settings");

            _checkIncomingOrders = new Timer() { Enabled = true, Interval = 10000 };
            _checkIncomingOrders.Start();

            Initialize += RunInitalize;
            InitializeOrderTransmission += OnInitializeOrderTransmission;
            ResultsReadyForExport += ExportResults;
            OnRequireInterpretation += MainViewModel_OnRequireInterpretation;
            OnQueryReceived += MainViewModel_OnQueryReceived;

            //invoke events
            Initialize?.Invoke(this, EventArgs.Empty);
            _checkIncomingOrders.Tick += OnIncomingOrders_Tick;
        }

        private void OnInitializeOrderTransmission(object sender, EventArgs e)
        {
            if (_processingIncomingOrders)
            { _logger.Info("Cannot tramsmit while processing incoming orders"); return; }
            _checkIncomingOrders.Enabled = false;

            #region Sanity Checks before handling orders
            _logger.Info("Checking for active analyser connection");
            _logger.Info($"Connection Status: {_lisParser?.Connection?.Status}");
            if (_lisParser?.Connection?.Status != 0) { return; }

            if (_lisParser is null) { _logger.Info("LIS Parser is null."); return; }
            if (_lisParser?.Connection is null) { _logger.Info("Connection is null."); return; }

            _logger.Info("Connection looks idle. Checking for communication");
            var IsCommunicationOk = _lisParser.Connection.EstablishSendMode();

            _lisParser.Connection.StopSendMode();
            if (!IsCommunicationOk) { _logger.Warn($"Cannot communicate with analyser."); return; }
            _logger.Info("Send mode established. Checking for incoming orders.");
            #endregion

            var message = BuildAstmMessage();
            try
            {

                if (message.Count > 0)
                {
                    _lisParser.SendRecords(message);
                    _ordersBuffer.Clear();
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Error sending records.");
                _logger.Error($"{ex.Message}\n{ex.StackTrace}");
            }

            _checkIncomingOrders.Enabled = true;
        }

        private List<AbstractLisRecord> BuildAstmMessage()
        {
            var lisRecordList = new List<AbstractLisRecord>();

            #region Header Record

            var header = new HeaderRecord()
            {
                SenderID = Settings.SenderName,
                ProcessingID = HeaderProcessingID.Production
            };
            lisRecordList.Add(header);
            #endregion

            for (int i = 0; i < _ordersBuffer.Count; i++)
            {
                var record = _ordersBuffer[i];

                #region Patient Record
                var patient = new PatientRecord()
                {
                    SequenceNumber = i + 1,
                    PracticeAssignedPatientId = record.NidPp, // get actual patient ID
                    LaboratoryAssignedPatientId = record.NidPp,
                    PatientName = new PatientName(record.Fullname),
                    Birthdate = record.Birthdate
                };
                lisRecordList.Add(patient);
                #endregion

                #region Order Record

                //assuming that the universal test id is already constructed and delimited by pipe '|' character
                var order = new OrderRecord()
                {
                    SequenceNumber = 1,
                    SpecimenID = record.Sid,
                    TestID = new UniversalTestID(record.Download.Replace("|", @"\")),
                    ReportType = OrderReportType.Order,
                    RequestedDateTime = DateTime.Now
                };

                if (record.SamplePriority) { order.Priority = OrderPriority.Stat; }
                else { order.Priority = OrderPriority.None; }

                lisRecordList.Add(order);

                #endregion

            }

            #region Terminator Record
            var terminator = new TerminatorRecord();
            lisRecordList.Add(terminator);
            #endregion

            return lisRecordList;

        }

        private void OnIncomingOrders_Tick(object sender, EventArgs e)
        {
            _processingIncomingOrders = true;
            var incomingOrders = new List<OrdersDownloadModel>();

            try
            {
                _checkIncomingOrders.Enabled = false;

                #region Sanity Checks before handling orders
                _logger.Info("Checking for active analyser connection");
                _logger.Info($"Connection Status: {_lisParser?.Connection?.Status}");
                if (_lisParser?.Connection?.Status != 0) { return; }

                if (_lisParser is null) { _logger.Info("LIS Parser is null."); return; }
                if (_lisParser?.Connection is null) { _logger.Info("Connection is null."); return; }

                _logger.Info("Connection looks idle. Checking for communication");
                var IsCommunicationOk = _lisParser.Connection.EstablishSendMode();
                if (!IsCommunicationOk) { _logger.Warn($"Cannot communicate with analyser."); return; }

                _lisParser.Connection.StopSendMode();
                _logger.Info("Send mode established. Checking for incoming orders.");
                #endregion

                var controlFiles = Directory.GetFiles(Settings.IncomingPath, $"*.{Settings.OrderControlFileExtension}");
                if (controlFiles is null) { _logger.Info("No incoming orders."); return; }
                if (controlFiles.Length == 0) { _logger.Info("No incoming orders."); return; }

                _logger.Info($"Detected {controlFiles.Length} record(s) incoming.");
                foreach (var controlFile in controlFiles)
                {
                    _logger.Info($"Processing for control file {controlFile}");
                    var orderDataFileInfo = new FileInfo
                        (controlFile.Replace(Settings.OrderControlFileExtension, Settings.OrderDataFileExtension));
                    var controlFileInfo = new FileInfo(controlFile);

                    _logger.Info($"Deleting control file");
                    if (controlFileInfo.Exists) { controlFileInfo.Delete(); }

                    if (TryGetOrderData(orderDataFileInfo, out var orderData))
                    {
                        incomingOrders.AddRange(orderData);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error($"{ex.Message}\n{ex.StackTrace}");
            }
            finally
            {
                _processingIncomingOrders = false;
                if (incomingOrders.Count > 0)
                {
                    _logger.Info($"Adding {incomingOrders.Count} record(s) to orders buffer");
                    _ordersBuffer.AddRange(incomingOrders);
                    InitializeOrderTransmission?.Invoke(this, EventArgs.Empty);

                    //checkIncomingOrders will be enabled after orders transmission 
                }
                else
                {
                    _checkIncomingOrders.Enabled = true;
                }
            }


        }

        private bool TryGetOrderData(FileInfo orderDataFileInfo, out List<OrdersDownloadModel> orderData)
        {
            orderData = new List<OrdersDownloadModel>();
            if (orderDataFileInfo.Exists)
            {
                try
                {
                    _logger.Info("Reading incoming orders data file");

                    var jsonData = File.ReadAllText(orderDataFileInfo.FullName);
                    var data = JsonConvert.DeserializeObject<List<OrdersDownloadModel>>(jsonData);
                    orderData.AddRange(data);

                    _logger.Info($"Deleting order file: {orderDataFileInfo.FullName}");
                    orderDataFileInfo.Delete();

                    return true;
                }
                catch (Exception ex)
                {
                    _logger.Error($"Error reading datafile(s)\n{ex.Message}\n{ex.StackTrace}");
                    return false;
                }
            }
            else
            {
                _logger.Warn($"Cannot find orders data file: {orderDataFileInfo.FullName}");
                return false;
            }
        }

        private async void MainViewModel_OnQueryReceived(object sender, QueryRecord e)
        {
            if (e is null)
            {
                _logger.Error("The query record for export is null. Skipping export step.");
                return;
            }

            //dispatch the query data to get order for the sample(s) in question
            var query = new List<dynamic>() { e };

            try
            {
                await _exportService.ExportQueryToOrderDownloaderAsync(query);
            }
            catch (Exception ex)
            {
                //initiate sending a response to analyser that there is no order for the sample
                //log the error
                _logger.Error($"An error occured while trying to fetch order for analyser query: {query}");
                _logger.Error(ex.Message + "\n" + ex.StackTrace);
            }
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
                _logger.Info($"Running interpretation for {item.TestCode} with result: {item.MeasurementValue} {item.Unit}");
                var resultArray = ((string)_script.GetInterpretation(item)).Split('|');
                var testCode = resultArray[testCodeIndex];
                var result = resultArray[resultIndex];
                var unit = resultArray[unitIndex];

                _logger.Info($"Interpretation: Test Code: {testCode} Result: {result} {unit}");

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

        private async void RunInitalize(object sender, EventArgs e)
        {
            await LoadAndInitializeScript();
            await InitializeAstmAsync();
        }

        private async Task LoadAndInitializeScript()
        {
            _logger.Info("Trying to load analyser specific scripts");

            try
            {
                var script = await _scriptDataAccess.LoadScriptByName(Settings.AnalyserName);
                if (string.IsNullOrEmpty(script))
                {
                    _logger.Info($"Failed to load the script. Script name: {Settings.AnalyserName}. Please make sure that a script exists with the name.");
                    _isScriptLoaded = false;
                    return;
                }
                _logger.Info("Script fetched successfully. Trying to initialize scripting engine.");


                //load script to execution engine
                _script = CSScript.Evaluator.LoadCode(script);


                //check the script
                if (_script.IsScriptLoaded())
                {
                    _isScriptLoaded = true;
                    _logger.Info($"Script Loaded Successfully. Script name: {Settings.AnalyserName}");
                }
            }
            catch (Exception ex)
            {
                _logger.Info($"Failed to initialize scripting engine. {ex.Message}");
            }
        }

        /// <summary>
        /// Event handler for ResultsReadyForExport
        /// </summary>
        private async void ExportResults(object sender, List<InterfaceResultsModel> e)
        {
            try
            {
                _logger.Debug(JsonConvert.SerializeObject(e));
                await _exportService.ExportToUploaderAsync(e, Settings.ExportBasepath, Settings.Extension, Settings.ControlExtension);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async Task InitializeAstmAsync()
        {
            switch (Settings.ConnectionMode)
            {
                case ConnectionMode.Ethernet:
                    var isPortValid = ushort.TryParse(Settings.Port.ToString(), out var uShortPort);
                    if (!isPortValid) { _logger.Error($"Invalid port defined: {Settings.Port}. Max value allowed for port is 65535"); return; }

                    _lowLevelConnection = new Lis01A02TCPConnection(Settings.IpAddress, uShortPort);
                    _lisConnection = new Lis01A2Connection(_lowLevelConnection);

                    await ConnectAsync();

                    break;
                case ConnectionMode.Serial:
                    _lowLevelConnection = new Lis01A02RS232Connection(Settings.SerialPort);
                    _lisConnection = new Lis01A2Connection(_lowLevelConnection);
                    await ConnectAsync();

                    break;
                default:
                    break;
            }
        }

        private async Task ConnectAsync()
        {
            _lisParser = new LISParser(_lisConnection);

            _lisParser.OnSendProgress += LISParser_OnSendProgress; //Send data progress will trigger this event
            _lisParser.OnReceivedRecord += LISParser_OnReceivedRecord; //incoming LIS frames will trigger this event
            try
            {
                if (Settings.IsSever && Settings.ConnectionMode == ConnectionMode.Ethernet)
                {
                    await ((Lis01A02TCPConnection)_lowLevelConnection).StartListeningAsync();
                }
                else
                {
                    _lisParser.Connection.Connect();
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Error connecting: {ex.Message}\n{ex.StackTrace}");
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
                    if (_tempResults != null) { _interfaceResults.Add(_tempResults); }

                    _tempResults = new InterfaceResultsModel()
                    {
                        SampleId = order.SpecimenID,
                        Measurements = new List<MeasurementValues>()
                    };

                    break;
                case LisRecordType.Result:
                    var result = (ResultRecord)e.ReceivedRecord;

                    string testCode = "";

                    testCode = string.Concat(result.UniversalTestID.TestID,
                        result.UniversalTestID.TestName,
                        result.UniversalTestID.TestType,
                        result.UniversalTestID.ManufacturerCode)
                        .ToString()
                        .Replace("^", "")
                        .Trim();

                    _tempResults.Measurements.Add(new MeasurementValues()
                    {
                        TestCode = testCode,
                        MeasurementValue = result.Data,
                        Unit = result.Units,
                    });

                    //Analyser name
                    _tempResults.InstrumentId.InstrumentCode = Settings.AnalyserName;
                    //completed date and time
                    if (result.TestCompletedDateTime.HasValue)
                    {
                        _tempResults.CompletedDateTime = result.TestCompletedDateTime
                            .Value.ToString("yyyyMMddHHmmssfff");
                    }

                    OnRequireInterpretation?.Invoke(this, _tempResults);

                    break;
                case LisRecordType.Comment:
                    break;
                case LisRecordType.Query:
                    var query = (QueryRecord)e.ReceivedRecord;
                    query.UserFieldNumberTwo = Settings.AnalyserName;
                    OnQueryReceived?.Invoke(this, query);
                    break;
                case LisRecordType.Terminator:
                    //add any temp results
                    if (_tempResults != null)
                    {
                        _interfaceResults.Add(_tempResults);
                    }
                    //export the results
                    Debug.WriteLine(JsonConvert.SerializeObject(_interfaceResults, Formatting.Indented));

                    ResultsReadyForExport?.Invoke(this, _interfaceResults);
                    _interfaceResults.Clear();
                    //set temp results data to null
                    _tempResults = null;
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
