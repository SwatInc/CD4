using AutoMapper;
using CD4.DataLibrary.DataAccess;
using CD4.UI.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CD4.UI.Library.ViewModel
{
    public class ResultEntryViewModel : INotifyPropertyChanged, IResultEntryViewModel
    {
        #region Private Properties
        private List<CodifiedResultsModel> TempCodifiedPhrasesList;
        private DateTime loadWorksheetFromDate;
        private readonly IWorkSheetDataAccess workSheetDataAccess;
        private readonly IMapper mapper;
        private readonly IResultDataAccess resultDataAccess;
        private readonly IStatusDataAccess statusDataAccess;
        #endregion

        #region Events
        //event that notifies user interface that new data has been loaded and that datagrids needs to be refreshed.
        public event EventHandler RequestDataRefreshed;
        public event EventHandler LoadAllStatusData;
        //Push logs to the UI layer
        public event EventHandler<string> PushingLogs;
        //Push messages that does not require user input tracking
        public event EventHandler<string> PushingMessages;
        #endregion

        #region Default Constructor
        public ResultEntryViewModel
            (IWorkSheetDataAccess workSheetDataAccess, IMapper mapper, IResultDataAccess resultDataAccess, IStatusDataAccess statusDataAccess)
        {
            RequestData = new List<RequestSampleModel>();
            SelectedResultData = new BindingList<ResultModel>();
            SelectedClinicalDetails = new BindingList<string>();
            SelectedRequestData = new RequestSampleModel();
            AllResultData = new List<ResultModel>();
            CodifiedPhrasesForSelectedTest = new BindingList<CodifiedResultsModel>();
            AllCodifiedPhrases = new List<CodifiedResultsModel>();
            TempCodifiedPhrasesList = new List<CodifiedResultsModel>();
            AllStatus = new List<StatusModel>();

            //set the date to load worksheet from
            LoadWorksheetFromDate = DateTime.Today;

            GenerateDemoData();
            this.workSheetDataAccess = workSheetDataAccess;
            this.mapper = mapper;
            this.resultDataAccess = resultDataAccess;
            this.statusDataAccess = statusDataAccess;
            GetWorkSheet().ConfigureAwait(true);
            SelectedResultData.ListChanged += UpdateDatabaseResults;
            LoadAllStatusData += GetAllStatusData;

            //load all status Data
            LoadAllStatusData?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Public Properties
        public DateTime LoadWorksheetFromDate
        {
            get => loadWorksheetFromDate; set
            {
                if (loadWorksheetFromDate == value) { return; }
                loadWorksheetFromDate = value;
                OnPropertyChanged();

            }
        }
        public List<RequestSampleModel> RequestData { get; set; }
        public BindingList<ResultModel> SelectedResultData { get; set; }
        private List<ResultModel> AllResultData { get; set; }
        public RequestSampleModel SelectedRequestData { get; set; }
        public BindingList<CodifiedResultsModel> CodifiedPhrasesForSelectedTest { get; set; }
        public BindingList<string> SelectedClinicalDetails { get; set; }
        public List<CodifiedResultsModel> AllCodifiedPhrases { get; set; }
        public List<StatusModel> AllStatus { get; set; }
        public StatusModel SelectedStatus { get; set; }

        #endregion

        #region Public Methods

        public async Task SetSelectedSampleAsync(RequestSampleModel requestSampleData)
        {
            if (requestSampleData is null) return;
            SelectedRequestData.Id = requestSampleData.Id;
            SelectedRequestData.NationalId = requestSampleData.NationalId;
            SelectedRequestData.PatientName = requestSampleData.PatientName;
            SelectedRequestData.PhoneNumber = requestSampleData.PhoneNumber;
            SelectedRequestData.ReceivedDate = requestSampleData.ReceivedDate;
            SelectedRequestData.Site = requestSampleData.Site;
            SelectedRequestData.Address = requestSampleData.Address;
            SelectedRequestData.AgeSex = requestSampleData.AgeSex;
            SelectedRequestData.AnalysisRequestId = requestSampleData.AnalysisRequestId;
            SelectedRequestData.AtollIslandCountry = requestSampleData.AtollIslandCountry;
            SelectedRequestData.Birthdate = requestSampleData.Birthdate;
            SelectedRequestData.Cin = requestSampleData.Cin;
            SelectedRequestData.ClinicalDetails = requestSampleData.ClinicalDetails;
            SelectedRequestData.CollectionDate = requestSampleData.CollectionDate;
            SelectedRequestData.EpisodeNumber = requestSampleData.EpisodeNumber;

            SetClinicalDetailsForSelectedSample(requestSampleData.ClinicalDetails);

            await DisplaySelectedSamplesResultsAsync(requestSampleData.Cin).ConfigureAwait(true);
        }

        public async Task SetTestCodifiedPhrasesAsync(ResultModel selectedTest)
        {

            if (selectedTest is null || selectedTest.DataType is null || selectedTest.Mask is null)
            { return; }
            CodifiedPhrasesForSelectedTest.Clear();
            TempCodifiedPhrasesList.Clear();
            if (selectedTest.DataType == "CODIFIED" && selectedTest.Mask.Contains('|'))
            {
                var codifiedPhraseIds = selectedTest.Mask.Split('|');
                TempCodifiedPhrasesList = await Task.Run(() =>
                {
                    return GetCodifiedPhrasesForIds(codifiedPhraseIds);
                }).ConfigureAwait(true);

                if (TempCodifiedPhrasesList.Count == 0) return;

                foreach (var phrase in TempCodifiedPhrasesList)
                {
                    CodifiedPhrasesForSelectedTest.Add(phrase);
                }
            }
        }

        public async Task ValidateTest(ResultModel resultModel)
        {
            try
            {
                var output = await statusDataAccess.ValidateTest(resultModel.Cin, resultModel.Test, resultModel.StatusIconId, resultModel.Result);
                UpdateUiAfterOnTestValidation(output, resultModel);
            }
            catch (Exception ex)
            {

                PushingMessages?.Invoke(this, ex.Message);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Fetches all status data from data layer. This data will be used as a datasource for the lookupedit status filter.
        /// </summary>
        private async void GetAllStatusData(object sender, EventArgs e)
        {
            //call the datalayer for the data.
            var result = await statusDataAccess.GetAllStatus();
            //automap the data onto a list of corresponding local model
            var statusModel = mapper.Map<List<StatusModel>>(result);
            //add the data to the datasource.
            foreach (var item in statusModel)
            {
                AllStatus.Add(item);
            }


        }

        /// <summary>
        /// Changes the test status icon on grid UI. Changes the sample status icon as validated if all the tests are validated.
        /// </summary>
        private void UpdateUiAfterOnTestValidation(bool output, ResultModel resultModel)
        {
            bool OkToMarkSampleValidated = true;
            bool IsRefreshUiGrids = false;
            //if output is true
            if (output)
            {//change the status icon to validated.
                foreach (var item in SelectedResultData)
                {
                    //if the validated test equals the current test being iterated...
                    if (item.Test == resultModel.Test)
                    {
                        //Set the StatusIconId to 5, which will internally change the icon to validated.
                        item.StatusIconId = 5;
                        //The UI needs to be refreshed.
                        IsRefreshUiGrids = true;
                    }
                    //Set the flag to set the sample status icon as validated.
                    if (item.StatusIconId != 5)
                    {
                        OkToMarkSampleValidated = false;
                    }
                }
            }
            //decide to mark set the sample icon as validated.
            if (OkToMarkSampleValidated)
            {
                //change the sample icon to validated.
                foreach (var item in RequestData)
                {
                    if (item.Cin == resultModel.Cin)
                    {
                        item.StatusIconId = 5;
                        //needs to refresh the UI
                        OkToMarkSampleValidated = true;
                    }
                }
            }

            //refresh the UI grids if required.
            if (IsRefreshUiGrids)
            {
                //Raise the event to notify the UI to refresh the grid datasource.
                RequestDataRefreshed?.Invoke(this, EventArgs.Empty);
            }
        }

        private async void UpdateDatabaseResults(object sender, ListChangedEventArgs e)
        {
            //detect when a result is modified.
            if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                var testData = SelectedResultData.ElementAt(e.NewIndex);
                await InsertUpdateResultByIdAsync(testData.Result, testData.Id);
            }
        }

        private async Task InsertUpdateResultByIdAsync(string result, int resultId)
        {
            var response = await resultDataAccess.InsertUpdateResultByResultIdAsync(resultId, result);
        }

        private void SetClinicalDetailsForSelectedSample(string delimitedDetails)
        {
            SelectedClinicalDetails.Clear();
            if (delimitedDetails is null) { return; }
            var details = delimitedDetails.Split(',');
            if (details.Length == 0) return;

            foreach (var item in details)
            {
                SelectedClinicalDetails.Add(item.Trim());
            }

        }
        private List<CodifiedResultsModel> GetCodifiedPhrasesForIds(string[] idsCodifiedPhrase)
        {
            var returnList = new List<CodifiedResultsModel>();
            foreach (var id in idsCodifiedPhrase)
            {
                var isIsInt = int.TryParse(id, out int parsedId);
                if (isIsInt)
                {
                    var match = AllCodifiedPhrases.Find((c) => c.Id == parsedId);
                    if (match is null) continue;
                    returnList.Add(match);
                }
            }
            return returnList;
        }
        private async Task DisplaySelectedSamplesResultsAsync(string cin)
        {
            if (cin is null) return;
            var selectedResult = await Task.Run(() =>
            {
                return AllResultData.FindAll((r) => r.Cin == cin);
            });

            if (selectedResult is null) return;
            SelectedResultData.Clear();

            foreach (var result in selectedResult)
            {
                SelectedResultData.Add(result);
            }

        }
        private void GenerateDemoData()
        {
            #region Request Data
            //var rq1 = new RequestSampleModel()
            //{
            //    Id = 1,
            //    AnalysisRequestId = 1,
            //    Cin = "nCoV-1236/20",
            //    CollectionDate = DateTime.Today,
            //    ReceivedDate = DateTime.Today,
            //    PatientName = "Ahmed Hussain",
            //    NationalId = "A29837",
            //    AgeSex = "30Y 3M 27D / MALE",
            //    Birthdate = DateTime.Today,
            //    PhoneNumber = "71261888",
            //    Address = "Some Adddress",
            //    AtollIslandCountry = "L. Gan, Maldives",
            //    EpisodeNumber = "SW7289889",
            //    Site = "FARUKOLHU",
            //    ClinicalDetails = "Fever, Cough"
            //};
            //var rq2 = new RequestSampleModel()
            //{
            //    Id = 2,
            //    AnalysisRequestId = 2,
            //    Cin = "nCoV-324528/20",
            //    CollectionDate = DateTime.Today,
            //    ReceivedDate = DateTime.Today,
            //    PatientName = "Kamal Nasir",
            //    NationalId = "A2346288",
            //    AgeSex = "30Y 3M 27D / MALE",
            //    Birthdate = DateTime.Today,
            //    PhoneNumber = "0917266767",
            //    Address = "Some Some Adddress",
            //    AtollIslandCountry = "Hulhumale, Male', Maldives",
            //    EpisodeNumber = "SW989787656",
            //    Site = "IGMH",
            //    ClinicalDetails = "SOB, Fever, Cough"
            //};

            //RequestData.Add(rq1);
            //RequestData.Add(rq2);
            #endregion

            #region AllResultsData
            //var rs1_1 = new ResultModel()
            //{
            //    Id = 1,
            //    AnalysisRequestId = 1,
            //    Cin = "nCoV-1236/20",
            //    Test = "E Gene",
            //    Result = "",
            //    DataType = "Numeric",
            //    Mask = "###.##"
            //};
            //var rs1_2 = new ResultModel()
            //{
            //    Id = 1,
            //    AnalysisRequestId = 1,
            //    Cin = "nCoV-324528/20",
            //    Test = "RdRp",
            //    Result = "",
            //    DataType = "CODIFIED",
            //    Mask = "1|2"
            //};

            //var rs1_3 = new ResultModel()
            //{
            //    Id = 1,
            //    AnalysisRequestId = 1,
            //    Cin = "nCoV-324528/20",
            //    Test = "E Gene",
            //    Result = "",
            //    DataType = "NUMERIC",
            //    Mask = "###.##"
            //};
            //AllResultData.Add(rs1_1);
            //AllResultData.Add(rs1_2);
            //AllResultData.Add(rs1_3);
            #endregion

            #region All Codified Phrases

            AllCodifiedPhrases.Add(new CodifiedResultsModel() { Id = 1, CodifiedValue = "POSITIVE" });
            AllCodifiedPhrases.Add(new CodifiedResultsModel() { Id = 2, CodifiedValue = "NEGATIVE" });
            AllCodifiedPhrases.Add(new CodifiedResultsModel() { Id = 3, CodifiedValue = "NOT DETECTED" });
            AllCodifiedPhrases.Add(new CodifiedResultsModel() { Id = 4, CodifiedValue = "DETECTED" });

            #endregion
        }

        public async Task GetWorkSheet()
        {
            var worksheet = await workSheetDataAccess.GetWorklistBySpecifiedDateAndStatusIdAsync
                (GetSelectedStatusIdOrDefault(),LoadWorksheetFromDate);
            await DisplayWorksheet(worksheet);

        }

       private int GetSelectedStatusIdOrDefault()
        {
            //declare a variable to hold the selected statusId
            int selectedStatusId;

            //Check whether the selected status is null...
            if (SelectedStatus is null)
            {
                //assign the Id as 4, which corresponds to the ToValidate status.
                selectedStatusId = 4;
            }
            else
            {
                //otherwise, return the actual selected status Id
                selectedStatusId = SelectedStatus.Id;
            }

            return selectedStatusId;
        }

        private async Task DisplayWorksheet(CD4.DataLibrary.Models.WorklistModel worklist)
        {
            //Clear current request data if any...
            RequestData.Clear();
            //Clear Test result data if any...
            AllResultData.Clear();
            //Clear Selected Result data if any..
            SelectedResultData.Clear();

            //return if PatientData is null
            if (worklist.PatientData is null)
            {
                RequestDataRefreshed?.Invoke(this, EventArgs.Empty);
                return;
            }

            //map out request data
            foreach (var item in worklist.PatientData)
            {
                //and map new data from database into the requestData list
                RequestData.Add(mapper.Map<RequestSampleModel>(item));
            }

            //if TestResultData is null return
            if (worklist.TestResultsData is null)
            {
                return;
            }

            //map out new result data
            foreach (var item in worklist.TestResultsData)
            {
                AllResultData.Add(mapper.Map<ResultModel>(item));
            }

            //notify UI that data has refreshed, so that UI knows to refresh datagrids
            RequestDataRefreshed?.Invoke(this, EventArgs.Empty);
        }

        #endregion

    }
}
