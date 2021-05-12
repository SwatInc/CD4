using CD4.DataLibrary.DataAccess;
using CD4.ExcelInterface.QuantStudio5.Models;
using CSScriptLibrary;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CD4.ExcelInterface.QuantStudio5.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged, IMainViewModel
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

        #endregion

        #region Public Properties
        public Config Configuration { get; set; }
        public BindingList<LogModel> Logs { get; set; }
        public BindingList<InterfaceResults> InterfaceResults { get; set; }
        public dynamic KitNames { get { return _kitNames; } private set => _kitNames = value; }

        #endregion

        #region Private Methods

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
            var batchId = "";
            if (!(e.Result is null))
            {
                var result = (List<InterfaceResults>)(e.Result);
                foreach (var item in result)
                {
                    if (string.IsNullOrEmpty(batchId)) { batchId = item.BatchId; }
                    item.InstrumentId.InstrumentCode = Configuration.AnalyserName;
                    InterfaceResults.Add(item);
                }

                result = null;
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(KitNames)));

            //replace targets with blank values with a dash(-)
            foreach (var interfaceResults in InterfaceResults)
            {
                foreach (var measurement in interfaceResults.Measurements)
                {
                    if(string.IsNullOrEmpty(measurement.MeasurementValue)) { measurement.MeasurementValue = "-"; }
                }
            }

            //run interpretations if analyser is QuantStudio
            if (batchId.ToLower().Contains("perkinelmer"))
            {
                Logs.Add(new LogModel() { Date = DateTime.Now, Log = "Auto selected PerkinElmer kit." });
                InterpretData(3);
            }
            if (batchId.ToLower().Contains("zeesan"))
            {
                Logs.Add(new LogModel() { Date = DateTime.Now, Log = "Auto selected Zeesan kit." });
                InterpretData(1);
            }
            if (batchId.ToLower().Contains("labgun"))
            {
                Logs.Add(new LogModel() { Date = DateTime.Now, Log = "Auto selected LabGun kit." });
                InterpretData(2);
            }

            if (batchId.ToLower().Contains("genedania"))
            {
                Logs.Add(new LogModel() { Date = DateTime.Now, Log = "Auto selected GENEdania kit." });
                InterpretData(4);
            }

            //auto export to LIS
            ExportToUploader().GetAwaiter().GetResult();
        }

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
                    var fileStream = MultipleTries(() => new FileStream(file, FileMode.Open, FileAccess.Read));
                    var results = ProcessExcelFile(fileStream);

                    //delete the file if it exists
                    FileInfo fileInfo = new FileInfo(file);
                    DeleteIfExists(fileInfo);

                    //handle processed data
                    if (results is null) { continue; }
                    if (results.Count > 0) { processedResults.AddRange(results); }
                    results = null;
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


        public T MultipleTries<T>(Func<T> function)
        {
            // https://stackoverflow.com/questions/1563191/cleanest-way-to-write-retry-logic

            var MaxTries = Configuration.FileReadMaxTries;
            var tries = MaxTries;
            var delay = Configuration.FileReadDelay;
            while (true)
            {
                try
                {
                    return function();
                }
                catch (Exception ex)
                {
                    if (--tries <= 0)
                    {
                        Logs.Add(new LogModel() { Log = $"Cannot read the file after {MaxTries} tries. Error Message: {ex.Message}" });
                        throw;
                    }
                    Logs.Add(new LogModel() { Log = $"Failed reading the file. Trying again in {delay} ms. Max tries is set as {MaxTries}" });
                    System.Threading.Thread.Sleep(delay);
                }
            }
        }

        private List<InterfaceResults> ProcessExcelFile(FileStream fileStream)
        {
            List<InterfaceResults> processedInterfaceResults = new List<InterfaceResults>();
            IWorkbook workbook = new XSSFWorkbook(fileStream);
            ISheet sheet = workbook.GetSheet("Results");


            try
            {
                if (sheet != null)
                {
                    //auto determine start row
                    if (Configuration.DataRange.AutoDetectStartRow.Active) { DetectStartRowAutomatically(sheet); }
                    //Get Experiment name
                    var experimentName = GetExperimentName(sheet);

                    for (int i = Configuration.DataRange.StartRow; i < Configuration.DataRange.EndRow; i++)
                    {
                        IRow dataRow = sheet.GetRow(i);
                        if (dataRow is null) { continue; }
                        var result = new InterfaceResults();

                        //position
                        var position = dataRow.GetCell(Configuration.SamplePositionColumn);
                        if (position is null) { continue; }
                        result.InstrumentId = new InstrumentIdentification() { TubePositionInRack = position.ToString() };

                        //Sample ID
                        var sid = dataRow.GetCell(Configuration.SidColumn);
                        result.SampleId = sid.ToString();
                        if (string.IsNullOrEmpty(result.SampleId)) { continue; }
                        result.ResultType = "NM";

                        //Batch Id
                        result.BatchId = experimentName;

                        //result
                        bool skipResult = false;
                        foreach (var item in Configuration.Measurements)
                        {
                            skipResult = false;
                            var testcode = dataRow.GetCell(item.TestCodeColumn)?.StringCellValue;
                            if (string.IsNullOrEmpty(testcode)) { continue; }

                            var sample = processedInterfaceResults.Find((x) => x.SampleId == result.SampleId);

                            //if sample number is already present in previous rows
                            if (!(sample is null))
                            {
                                //Check whether the specific test code is present in the sample.
                                var measurement = sample.Measurements.FirstOrDefault((x) => x.TestCode == testcode);

                                //if testcode is already present...
                                if (measurement != null)
                                {
                                    //overwrite the result.
                                    var testResult = dataRow.GetCell(item.MeasurementValueColumn)?.ToString();
                                    Logs.Add(new LogModel() 
                                    { 
                                        Log = $"{testcode} is already present for sample number. Test result: {measurement.MeasurementValue} "+
                                                $"replaced by Test Result: {testResult}"
                                    });
                                    measurement.MeasurementValue = testResult;
                                }
                                else
                                {
                                    //if testcode is not present for sample..., add it.
                                    sample.Measurements.Add(new MeasurementValues()
                                    {
                                        TestCode = testcode,
                                        MeasurementValue = dataRow.GetCell(item.MeasurementValueColumn)?.ToString()
                                    });
                                }
                                skipResult = true;
                            }
                            else
                            {
                                //if new sample number
                                result.Measurements.Add(new MeasurementValues()
                                {
                                    TestCode = testcode,
                                    MeasurementValue = dataRow.GetCell(item.MeasurementValueColumn)?.ToString()
                                });
                                skipResult = false;
                            }


                        }
                        //add the results to a temp list..., if the result has a sample Id
                        if (!string.IsNullOrEmpty(result.SampleId) && !skipResult) processedInterfaceResults.Add(result);
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
            finally
            {
                fileStream.Close();
            }

        }

        private string GetExperimentName(ISheet sheet)
        {
            var experimentName = "";
            var keywords = Configuration.BatchId.CsvKeywords.Split(',');
            //scan until start row
            for (int i = 0; i < Configuration.DataRange.StartRow; i++)
            {
                IRow row = sheet.GetRow(i);
                if (row is null) { continue; }
                var rowValue = (row.GetCell(Configuration.BatchId.ScanColumnIndex)).StringCellValue;

                //iaterate all keywords to find a match
                foreach (var item in keywords)
                {
                    if (rowValue.Contains(item.Trim()))
                    {
                        //get the data from data column
                        var dataValue = (row.GetCell(Configuration.BatchId.DataColumnIndex)).StringCellValue;

                        if (dataValue.Contains("\\"))
                        {
                            var data = dataValue.Substring(dataValue.LastIndexOf('\\') + 1);
                            experimentName = $"{experimentName} {data}";
                            continue;
                        }

                        if (!(experimentName.Contains(dataValue.Trim()))) { experimentName = $"{experimentName} {dataValue}"; }

                    }
                }

            }

            Logs.Add(new LogModel() { Log = $"Experiment Name: {experimentName}" });
            return experimentName.Replace(".eds", "").Trim();

        }

        /// <summary>
        /// automatically detects data start row based on configuration
        /// </summary>
        /// <param name="sheet">The sheet to read through to detect start row</param>
        private void DetectStartRowAutomatically(ISheet sheet)
        {
            try
            {
                //iterate 1st 200 rows... exit loop early if keyword is found
                for (int i = 1; i < 200; i++)
                {
                    //get the currnt row cell value
                    IRow row = sheet.GetRow(i);
                    if (row is null) { continue; }
                    var rowValue = (row.GetCell(Configuration.DataRange.AutoDetectStartRow.ColumnIndex)).StringCellValue;

                    //if the cell value equals the keyword.... 
                    if (rowValue == Configuration.DataRange.AutoDetectStartRow.Keyword)
                    {
                        //next row is the start row
                        var startRow = i + 1;
                        Logs.Add(new LogModel() { Log = $"Auto-detected start row: {startRow}" });
                        //overwrite config start row data
                        Configuration.DataRange.StartRow = startRow;
                        //exit the for loop
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.Add(new LogModel() { Log = $"An error occured while trying to detect starting row: {ex.Message}" });
            }

        }

        private void DeleteIfExists(FileInfo fileInfo)
        {
            try
            {
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                    Logs.Add(new LogModel() { Log = "Job completed" });
                }
            }
            catch (Exception ex)
            {
                Logs.Add(new LogModel() { Log = $"An error while trying to delete the file {fileInfo.Name}: {ex.Message}" });
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


            try
            {
                fileSystemWatcher.Path = Configuration.ExcelFileDirectory;
                fileSystemWatcher.EnableRaisingEvents = true;
                Logs.Add(new LogModel() { Log = $"Listening for analyser exports on {Configuration.ExcelFileDirectory}" });
            }
            catch (Exception ex)
            {
                Logs.Add(new LogModel() { Log = $"An error occured while setting up file system watcher. Please restart interface.\n{ex.Message}" });
            }

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
                InterfaceResults.Clear();
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
