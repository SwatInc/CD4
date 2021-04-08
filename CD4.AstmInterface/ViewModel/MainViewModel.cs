using CD4.AstmInterface.Model;
using CD4.ResultsInterface.Common.Models;
using CD4.ResultsInterface.Common.Services;
using Essy.LIS.Connection;
using Essy.LIS.LIS02A2;
using log4net.Core;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
            Settings = new Settings();
            interfaceResults = new List<InterfaceResultsModel>();
            exportService = new ExportService();
            logger.LogInformation("Application startup... loaded settings");

            InitializeAstm();
            
            ResultsReadyForExport += ExportResults;
            this.logger = logger;
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
                    //Not implemented yet
                    throw new NotImplementedException("Ethernet connection not implemented!");
                    break;
                case ConnectionMode.Serial:
                    lowLevelConnection = new Lis01A02RS232Connection(Settings.SerialPort);
                    lisConnection = new Lis01A2Connection(lowLevelConnection);
                    lisParser = new LISParser(lisConnection);
                    
                    lisParser.OnSendProgress += LISParser_OnSendProgress; //Send data progress will trigger this event
                    lisParser.OnReceivedRecord += LISParser_OnReceivedRecord; //incoming LIS frames will trigger this event
                    try
                    {
                        lisParser.Connection.Connect();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    break;
                default:
                    break;
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
                    if (tempResults != null )  { interfaceResults.Add(tempResults); }

                    tempResults = new InterfaceResultsModel() {
                        SampleId = order.SpecimenID,
                        Measurements = new List<MeasurementValues>()
                    };

                    break;
                case LisRecordType.Result:
                    var result = (ResultRecord)e.ReceivedRecord;
                    tempResults.Measurements.Add(new MeasurementValues() 
                    {
                         TestCode = result.UniversalTestID.ManufacturerCode,
                         MeasurementValue = result.Data,
                         Unit = result.Units,
                    });

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
                        return (ILisConnection)Activator.CreateInstance(item,new Lis01A02RS232Connection(Settings.SerialPort));
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
