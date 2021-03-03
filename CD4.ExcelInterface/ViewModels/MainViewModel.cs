using CD4.DataLibrary.DataAccess;
using CD4.ExcelInterface.Models;
using CSScriptLibrary;
using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CD4.ExcelInterface.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Private Fields
        dynamic _script;
        private List<dynamic> _kitNames;
        private List<string> _filesToProcess { get; set; }
        private bool _isScriptLoaded;
        private IResultDataAccess _resultDataAccess;
        private IScriptDataAccess _scriptDataAccess;
        private dynamic kitNames;
        private readonly Timer _initiateJobTimer = new Timer() { Interval = 2000, AutoReset = false, Enabled = false };
        private readonly BackgroundWorker _backgroundWorker;
        private readonly FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();

        public event PropertyChangedEventHandler PropertyChanged;
        private event EventHandler Initialize;

        #endregion

        #region Default Constructor
        public MainViewModel()
        {
            _kitNames = new List<dynamic>();
            _isScriptLoaded = false;
            _filesToProcess = new List<string>();
            InterfaceResults = new BindingList<InterfaceResults>();
            Logs = new BindingList<LogModel>();
            Configuration = new Config();
            var appSettings = new Properties.Settings();
            Configuration = JsonConvert.DeserializeObject<Config>(appSettings.Config);
            _resultDataAccess = new ResultDataAccess(new StatusDataAccess(), new ReferenceRangeDataAccess(), new SampleDataAccess());
            _scriptDataAccess = new ScriptDataAccess();
            ConfigureFileSystemWatcher();

            //BackgroundWorker config
            _backgroundWorker = new BackgroundWorker() { WorkerReportsProgress = true };
            _backgroundWorker.DoWork += new DoWorkEventHandler(ProcessResults);
            _backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(ReportProgressChanged);
            _backgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;

            //Event subscriptions
            fileSystemWatcher.Created += OnFileDetectedInDirectory;
            _initiateJobTimer.Elapsed += OnInitiateJob;
            Initialize += RunInitalze;


            //invoke events
            Initialize?.Invoke(this, EventArgs.Empty);
        }

        private async void RunInitalze(object sender, EventArgs e)
        {
            await LoadAndInitializeScript();
        }

        private async Task LoadAndInitializeScript()
        {
            Logs.Add(new LogModel() { Log = $"Trying to load analyser specific scripts" });

            try
            {
                var script = await _scriptDataAccess.LoadScriptByName(Configuration.AnalyserName);
                if (string.IsNullOrEmpty(script))
                {
                    Logs.Add(new LogModel() { Log = $"Failed to load the script. Script name: {Configuration.AnalyserName}. Please make sure that a script exists with the name." });
                    _isScriptLoaded = false;
                    return;
                }

                //load script to execution engine
                _script = CSScript.LoadCode(script).CreateObject("*");

                //check the script
                if (_script.IsScriptLoaded())
                {
                    _isScriptLoaded = true;
                    Logs.Add(new LogModel() { Log = $"Script Loaded Successfully. Script name: {Configuration.AnalyserName}" });
                    var kits = _script.GetKitNames();
                    foreach (var item in kits)
                    {
                        KitNames.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.Add(new LogModel() { Log = $"Failed to initialize scripting engine. {ex.Message}" });
            }
        }

        private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!(e.Result is null))
            {
                var result = (List<InterfaceResults>)(e.Result);
                foreach (var item in result)
                {
                    item.InstrumentId.InstrumentCode = Configuration.AnalyserName;
                    InterfaceResults.Add(item);
                }
            }

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(KitNames)));
        }
        #endregion

        #region Public Properties
        public Config Configuration { get; set; }
        public BindingList<LogModel> Logs { get; set; }
        public BindingList<InterfaceResults> InterfaceResults { get; set; }
        public dynamic KitNames { get { return _kitNames; } private set => _kitNames = value; }

        #endregion

        #region Private Methods

        private void ReportProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                Logs.Add(new LogModel() { Log = (string)e.UserState });
            }
            catch (Exception ex)
            {
                Logs.Add(new LogModel() { Log = ex.Message });
            }
        }
        private void ProcessResults(object sender, DoWorkEventArgs e)
        {
            List<InterfaceResults> processedResults = new List<InterfaceResults>();
            try
            {
                foreach (var file in _filesToProcess)
                {

                    FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);

                    var results = ProcessExcelFile(fileStream);

                    //delete the file if it exists
                    FileInfo fileInfo = new FileInfo(file);
                    DeleteIfExists(fileInfo);

                    //handle processed data
                    if (results is null) { continue; }
                    if (results.Count > 0) { processedResults.AddRange(results); }
                }
            }
            catch (Exception ex)
            {
                Logs.Add(new LogModel() { Log = ex.Message });
            }
            finally
            {
                Logs.Add(new LogModel() { Log = "Clearing processing queue" });

                //dont make the display logs too long. Clear to remove unnecessary RAM
                if (Logs.Count > 50) { Logs.Clear(); }
                _filesToProcess.Clear();

                //return back the data
                e.Result = processedResults;
            }
        }
        private List<InterfaceResults> ProcessExcelFile(FileStream fileStream)
        {
            List<InterfaceResults> processedInterfaceResults = new List<InterfaceResults>();
            IWorkbook workbook = new HSSFWorkbook(fileStream);
            ISheet sheet = workbook.GetSheetAt(0);

            //Get Experiment name
            IRow row = sheet.GetRow(0);
            var experimentName = row.GetCell(0);
            try
            {
                if (sheet != null)
                {
                    for (int i = Configuration.DataRange.StartRow; i < Configuration.DataRange.EndRow; i++)
                    {
                        var result = new InterfaceResults();
                        IRow dataRow = sheet.GetRow(i);

                        //position
                        var position = dataRow.GetCell(Configuration.SamplePositionColumn);
                        if (position is null) { continue; }
                        result.InstrumentId = new InstrumentIdentification() { TubePositionInRack = position.ToString() };

                        //Sample ID
                        var sid = dataRow.GetCell(Configuration.SidColumn);
                        result.SampleId = sid.ToString();
                        result.ResultType = "NM";

                        //Batch Id
                        result.BatchId = experimentName.StringCellValue;

                        //result
                        foreach (var item in Configuration.Measurements)
                        {
                            var testcode = dataRow.GetCell(item.TestCodeColumn)?.StringCellValue;
                            if (string.IsNullOrEmpty(testcode)) { continue; }
                            result.Measurements.Add(new MeasurementValues()
                            {
                                TestCode = testcode,
                                MeasurementValue = dataRow.GetCell(item.MeasurementValueColumn)?.ToString()
                            });
                        }
                        //add the results to a temp list..., if the result has a sample Id
                        if (!string.IsNullOrEmpty(result.SampleId)) processedInterfaceResults.Add(result);
                    }
                }
                //report progress
                _backgroundWorker.ReportProgress(1, $" {JsonConvert.SerializeObject(processedInterfaceResults)}");
                return processedInterfaceResults;
            }
            catch (Exception ex)
            {
                _backgroundWorker.ReportProgress(1, $"An Error occured {ex.Message}. Excel file not processed!");
                return new List<InterfaceResults>();
            }

        }
        private void DeleteIfExists(FileInfo fileInfo)
        {
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
                Logs.Add(new LogModel() { Log = "Job completed" });
            }
        }
        private void OnInitiateJob(object sender, ElapsedEventArgs e)
        {
            _backgroundWorker.RunWorkerAsync();
        }
        private void ConfigureFileSystemWatcher()
        {
            fileSystemWatcher.Filter = Configuration.LisExportExtension;
            if (string.IsNullOrEmpty(Configuration.ExcelFileDirectory))
            {
                Logs.Add(new LogModel() { Log = "Analyser export directory is not set. Please exit interface and configure LIS export path." });
                return;
            }

            fileSystemWatcher.Path = Configuration.ExcelFileDirectory;
            fileSystemWatcher.EnableRaisingEvents = true;
            Logs.Add(new LogModel() { Log = $"Listening for analyser exports on {Configuration.ExcelFileDirectory}" });
        }
        private void OnFileDetectedInDirectory(object sender, FileSystemEventArgs e)
        {
            Logs.Add(new LogModel() { Log = e.FullPath });
            _filesToProcess.Add(e.FullPath);
            _initiateJobTimer.Enabled = true;
        }

        #endregion

        #region Public Methods
        public void InterpretData(int selectedKitId)
        {
            //check whether the script is loaded... return otherwise
            if (!_isScriptLoaded)
            {
                Logs.Add(new LogModel() { Log = $"Cannot interpret data. Script [ {Configuration.AnalyserName} ] not loaded" });
                return;
            }

            if (InterfaceResults.Count == 0)
            {
                Logs.Add(new LogModel() { Log = "No results in queue to process" });
                return;
            }
            foreach (var item in InterfaceResults)
            {
                //check whether the interpretation test is already present.
                var test = item.Measurements.Find((x) => x.TestCode == _script.GetInterpretationTestCode());
                var testAndResult = ((string)_script.GetInterpretation(selectedKitId, item.Measurements)).Split('|');

                if (test is null)
                {
                    item.Measurements.Add(new MeasurementValues()
                    {
                        TestCode = testAndResult[0],
                        MeasurementValue = testAndResult[1]
                    });
                }
                else
                {
                    test.MeasurementValue = testAndResult[1];
                }

            }
        }

        public async Task<bool> ExportToUploader()
        {
            if (InterfaceResults.Count == 0)
            {
                Logs.Add(new LogModel() { Log = "No results in queue to export to LIS" });
                return false;
            }

            var isSuccessfull = false;
            var exportData = JsonConvert.SerializeObject(InterfaceResults);
            var asciiencoding = new ASCIIEncoding();
            var filenameWithoutExtension = $"{Configuration.ExportPath}\\{DateTime.Now.ToString("yyyyMMdd_HHmmss_fffffff")}";

            byte[] result = asciiencoding.GetBytes(exportData);
            try
            {
                using (FileStream SourceStream = File.Open($"{filenameWithoutExtension}.{Configuration.DataExtension}", FileMode.OpenOrCreate))
                {
                    SourceStream.Seek(0, SeekOrigin.End);
                    await SourceStream.WriteAsync(result, 0, result.Length);
                }
                File.WriteAllText($"{filenameWithoutExtension}.{Configuration.ControlFileExtension}", "");
                isSuccessfull = true;
            }
            catch (Exception ex)
            {
                Logs.Add(new LogModel() { Log = ex.Message });
            }

            return isSuccessfull;

        }
        #endregion


    }
}
