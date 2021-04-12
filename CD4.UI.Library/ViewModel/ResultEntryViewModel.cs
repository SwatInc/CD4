using AutoMapper;
using CD4.DataLibrary.DataAccess;
using CD4.DataLibrary.Models;
using CD4.UI.Library.Helpers;
using CD4.UI.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public class ResultEntryViewModel : INotifyPropertyChanged, IResultEntryViewModel
    {
        #region Private Properties
        private List<Model.CodifiedResultsModel> TempCodifiedPhrasesList;
        private DateTime _loadWorksheetFromDate;
        private bool _isloadWorkSheetButtonEnabled;
        private bool _isLoadingAnimationEnabled;
        private GridControlTestActiveDatasource _gridTestActiveDatasource;
        private GridControlSampleActiveDatasource _gridSampleActiveDatasource;
        private int _selectedDisciplineId;
        private string notesCountButtonLabel;
        private readonly IWorkSheetDataAccess _workSheetDataAccess;
        private readonly IMapper _mapper;
        private readonly IResultDataAccess _resultDataAccess;
        private readonly IStatusDataAccess _statusDataAccess;
        private readonly ISampleDataAccess _sampleDataAccess;
        private readonly IStaticDataDataAccess _staticDataDataAccess;
        private readonly AuthorizeDetailEventArgs _authorizeDetail;
        #endregion

        #region Events
        //event that notifies user interface that new data has been loaded and that datagrids needs to be refreshed.
        public event EventHandler RequestDataRefreshed;
        public event EventHandler LoadAllStatusDataAndCodifiedValues;
        public event EventHandler LoadInitialWorklist;
        //Push logs to the UI layer
        public event EventHandler<string> PushingLogs;
        //Push messages that does not require user input tracking
        public event EventHandler<string> PushingMessages;
        #endregion

        #region Default Constructor
        public ResultEntryViewModel
            (IWorkSheetDataAccess workSheetDataAccess, IMapper mapper, IResultDataAccess resultDataAccess, IStatusDataAccess statusDataAccess,
            ISampleDataAccess sampleDataAccess, IStaticDataDataAccess staticDataDataAccess, AuthorizeDetailEventArgs authorizeDetail)
        {
            GridTestActiveDatasource = GridControlTestActiveDatasource.Tests;
            GridSampleActiveDatasource = GridControlSampleActiveDatasource.Sample;
            RequestData = new List<RequestSampleModel>();
            SelectedResultData = new BindingList<ResultModel>();
            SelectedClinicalDetails = new BindingList<string>();
            SelectedRequestData = new RequestSampleModel();
            AllResultData = new List<ResultModel>();
            CodifiedPhrasesForSelectedTest = new BindingList<Model.CodifiedResultsModel>();
            AllCodifiedPhrases = new List<Model.CodifiedResultsModel>();
            TempCodifiedPhrasesList = new List<Model.CodifiedResultsModel>();
            AllStatus = new List<Model.StatusModel>();
            SampleAuditTrail = new List<Model.AuditTrailModel>();
            NotesCountButtonLabel = "View Notes [ Ctrl+N ]";
            //set the date to load worksheet from
            LoadWorksheetFromDate = DateTime.Today;

            //GenerateDemoData();
            this._workSheetDataAccess = workSheetDataAccess;
            this._mapper = mapper;
            this._resultDataAccess = resultDataAccess;
            this._statusDataAccess = statusDataAccess;
            _sampleDataAccess = sampleDataAccess;
            _staticDataDataAccess = staticDataDataAccess;
            _authorizeDetail = authorizeDetail;
            SelectedResultData.ListChanged += UpdateDatabaseResults;
            LoadAllStatusDataAndCodifiedValues += GetAllStatusData;
            LoadAllStatusDataAndCodifiedValues += FetchAllCodifiedData;
            LoadInitialWorklist += ResultEntryViewModel_LoadInitialWorklist;

            //load all status Data
            LoadAllStatusDataAndCodifiedValues?.Invoke(this, EventArgs.Empty);
            //Load initial Worklist
            LoadInitialWorklist?.Invoke(this, EventArgs.Empty);
        }

        private async void ResultEntryViewModel_LoadInitialWorklist(object sender, EventArgs e)
        {
            try
            {
                await GetWorkSheet();
            }
            catch (Exception ex)
            {
                PushingMessages?.Invoke(this, ex.Message);
            }

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
            get => _loadWorksheetFromDate; set
            {
                if (_loadWorksheetFromDate == value) { return; }
                _loadWorksheetFromDate = value;
                OnPropertyChanged();

            }
        }
        public List<RequestSampleModel> RequestData { get; set; }
        public dynamic TestHistoryData { get; set; }
        public BindingList<ResultModel> SelectedResultData { get; set; }
        public List<Model.AuditTrailModel> SampleAuditTrail { get; set; }
        private List<ResultModel> AllResultData { get; set; }
        public RequestSampleModel SelectedRequestData { get; set; }
        public BindingList<Model.CodifiedResultsModel> CodifiedPhrasesForSelectedTest { get; set; }
        public BindingList<string> SelectedClinicalDetails { get; set; }
        public List<Model.CodifiedResultsModel> AllCodifiedPhrases { get; set; }
        public List<Model.StatusModel> AllStatus { get; set; }
        public Model.StatusModel SelectedStatus { get; set; }
        public int SelectedDisciplineId
        {
            get => _selectedDisciplineId; set
            {
                if (_selectedDisciplineId == value) return;
                _selectedDisciplineId = value;
                //no need to raise npc, load worksheet instead
                GetWorkSheet();
            }
        }
        public string NotesCountButtonLabel
        {
            get => notesCountButtonLabel; set
            {
                if (notesCountButtonLabel == value) return;
                notesCountButtonLabel = value;
                OnPropertyChanged();
            }
        }

        //enable/disable status of loadWorksheet button
        public bool IsloadWorkSheetButtonEnabled
        {
            get => _isloadWorkSheetButtonEnabled;
            set
            {
                //if the value is already set....
                if (_isloadWorkSheetButtonEnabled == value)
                {
                    //return without setting it again
                    return;
                }
                //set the new value
                _isloadWorkSheetButtonEnabled = value;
                //set the loading animation, loading animation will be enabled when button is disabled
                IsLoadingAnimationEnabled = !value;
                //Raise property changed
                OnPropertyChanged();
            }
        }
        public bool IsLoadingAnimationEnabled
        {
            get => _isLoadingAnimationEnabled; set
            {
                _isLoadingAnimationEnabled = value;
                OnPropertyChanged();
            }
        }

        public GridControlTestActiveDatasource GridTestActiveDatasource
        {
            get => _gridTestActiveDatasource; set
            {
                if (_gridTestActiveDatasource == value) return;
                _gridTestActiveDatasource = value;
                OnPropertyChanged();
            }
        }

        public GridControlSampleActiveDatasource GridSampleActiveDatasource
        {
            get => _gridSampleActiveDatasource; set
            {
                if (_gridSampleActiveDatasource == value) return;
                _gridSampleActiveDatasource = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets notes count button without a database call. Uses the passed in string value as count of notes
        /// </summary>
        /// <param name="notesCount">The number of notes as a string</param>
        public void SetNotesCountManually(string notesCount)
        {
            NotesCountButtonLabel = $"View Notes ( {notesCount} ) [ Ctrl+N ]";
        }

        public async Task GetNotesCountAsync(string cin)
        {
            var notesCount = await _sampleDataAccess.GetNotesCountAsync(cin);
            NotesCountButtonLabel = $"View Notes ( {notesCount} ) [ Ctrl+N ]";
        }

        public async Task RefreshResultDataOnUiAsync(string cin)
        {
            try
            {
                var data = await _resultDataAccess.GetResultAndResultStatusDataByCin(cin);
                UpdateUiOnAddingReflexTests(data, cin);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public enum GridControlTestActiveDatasource
        {
            Tests,
            AuditTrail,
            None
        }

        public enum GridControlSampleActiveDatasource
        {
            Sample,
            TestHistory
        }

        /// <summary>
        /// Cancels the rejection of a rejected sample and associated tests.
        /// </summary>
        /// <param name="cin">The CIN for sample to reject</param>
        public async Task CancelSampleRejection(string cin)
        {
            try
            {
                //call datalayer to cancel sample rejection
                var output = await _sampleDataAccess.CancelSampleRejectionByCinAsync(cin, 1);
                //map-out the result returned.
                var mappedData = _mapper.Map<SampleAndResultStatusAndResultModel>(output);
                //updateUI
                UpdateUiOnSampleRejectionOrRejectionCancellation(mappedData);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool CanRejectSample(RequestSampleModel sampleToReject)
        {
            if (sampleToReject.StatusIconId == 1 || sampleToReject.StatusIconId == 5 || sampleToReject.StatusIconId == 7)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CanRejectTest(ResultModel sampleToReject)
        {
            if (sampleToReject.StatusIconId == 1 || sampleToReject.StatusIconId == 5 || sampleToReject.StatusIconId == 7)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Rejects a sample with CIN and user provided reason for rejection.
        /// </summary>
        /// <param name="cin">The CIN of the sample to reject</param>
        /// <param name="commentListId">The DB Id of the user selected comment.</param>
        public async Task RejectSampleAsync(string cin, int commentListId)
        {
            try
            {
                //call datalayer to reject the sample.
                var output = await _sampleDataAccess.RejectSampleAsync(cin, commentListId, _authorizeDetail.UserId);
                //map-out the result returned.
                var mappedData = _mapper.Map<SampleAndResultStatusAndResultModel>(output);
                //updateUI
                UpdateUiOnSampleRejectionOrRejectionCancellation(mappedData);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Fetches sample audit trail from datalayer and maps the results to SampleAuditTrail list
        /// </summary>
        /// <param name="cin">The cin for the sample to fetch the audit trail data</param>
        public async Task GetSampleAuditTrailByCinAsync(string cin)
        {
            try
            {
                //get the audit trail from datasource
                var trail = await _sampleDataAccess.GetAuditTrailByCinAsync(cin);
                //map the trail to this libraries trail model
                SampleAuditTrail = _mapper.Map<List<Model.AuditTrailModel>>(trail);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task GetWorkSheet()
        {
            if (GetSelectedStatusIdOrDefault() == 0)
            {

                await LoadWorkSheetWithAllSamplesFromDateAsync();
                return;
            }
            try
            {
                //Disable the load worksheet button to avoid multiple clicks
                IsloadWorkSheetButtonEnabled = false;
                var worksheet = await _workSheetDataAccess.GetWorklistBySpecifiedDateAndStatusIdAsync
                    (GetSelectedStatusIdOrDefault(), SelectedDisciplineId, LoadWorksheetFromDate);
                await DisplayWorksheet(worksheet);
            }
            finally
            {
                //enable the load worksheet button again even if the call fails
                IsloadWorkSheetButtonEnabled = true;
            }
        }

        private async Task LoadWorkSheetWithAllSamplesFromDateAsync()
        {
            try
            {
                //Disable the load worksheet button to avoid multiple clicks
                IsloadWorkSheetButtonEnabled = false;
                var worksheet = await _workSheetDataAccess.GetWorklistBySpecifiedDateAndAllStatusAsync(SelectedDisciplineId, LoadWorksheetFromDate);
                await DisplayWorksheet(worksheet);
            }
            finally
            {
                //enable the load worksheet button again even if the call fails
                IsloadWorkSheetButtonEnabled = true;
            }
        }

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

        /// <summary>
        /// Mark the test as validated.
        /// </summary>
        /// <param name="resultModel">Result model with the test information of test to be validated</param>
        /// <returns>a Task</returns>
        public async Task ValidateTest(ResultModel resultModel)
        {
            try
            {
                //mark the test as validated.
                var output = await _statusDataAccess.ValidateTest(resultModel.Cin, resultModel.Test, resultModel.StatusIconId, resultModel.Result, _authorizeDetail.UserId);
                //Update the UI to show that the test as validated...ie., if it has been validated.
                UpdateUiAfterOnTestValidation(output, resultModel);
            }
            catch (Exception ex)
            {
                //Push the error message to UI
                PushingMessages?.Invoke(this, ex.Message);
            }
        }

        /// <summary>
        /// Marks the sample and all the applicable for the sample as validated.
        /// </summary>
        public async Task ValidateSample(RequestSampleModel requestSampleModel)
        {
            try
            {
                var output = await _statusDataAccess.ValidateSample(requestSampleModel.Cin, requestSampleModel.StatusIconId, _authorizeDetail.UserId);
                UpdateUiAOnSampleValidation(output, requestSampleModel);
            }
            catch (Exception ex)
            {

                PushingMessages?.Invoke(this, ex.Message);
            }
        }

        /// <summary>
        /// updates the status icon on UI to match with the database status returned after sample validation
        /// </summary>
        /// <param name="output"></param>
        /// <param name="requestSampleModel"></param>
        private void UpdateUiAOnSampleValidation
            (StatusUpdatedSampleAndTestStatusModel output, RequestSampleModel requestSampleModel)
        {
            //1. update any changes in status for analyses for the sample.

            //if the now selected sample is the sample that was validated...
            if (SelectedRequestData.Cin == requestSampleModel.Cin)
            {

                //iterate the selected sample... to update tests status in sample.
                foreach (var item in SelectedResultData)
                {
                    //get the test status for current item...
                    var testStatus = output.TestStatusList.Find((x) => x.TestId == item.Id);
                    //update UI status
                    item.StatusIconId = testStatus.StatusId;
                }

            }

            //Update UI sample status
            this.RequestData.First(r => r.Cin == output.SampleStatus.Cin).StatusIconId = output.SampleStatus.StatusId;

            //Raise the event to notify the UI to refresh the grid datasource.
            RequestDataRefreshed?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Fetches all status data from data layer. This data will be used as a datasource for the lookupedit status filter.
        /// </summary>
        private async void GetAllStatusData(object sender, EventArgs e)
        {
            try
            {
                //call the datalayer for the data.
                var result = await _statusDataAccess.GetAllStatus();
                //automap the data onto a list of corresponding local model
                var statusModel = _mapper.Map<List<Model.StatusModel>>(result);
                //add the data to the datasource.
                AllStatus.Add(new Model.StatusModel() { Id = 0, Status = "All" });
                foreach (var item in statusModel)
                {
                    AllStatus.Add(item);
                }
            }
            catch (Exception ex)
            {
                PushingMessages?.Invoke(this, ex.Message);
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
                        //The icon id 5 corresponds to validated icon. Show on the UI, sample as validated.
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

        /// <summary>
        /// update UI (Grid displaying tests) after result is pushed to the database. 
        /// </summary>
        /// <param name="response">The model containing updated data</param>
        private void UpdateUiOnResultEntry(UpdatedResultAndStatusModel response)
        {
            //get the item to update from Selected Result Data
            var ItemToUpdate = SelectedResultData.Where(x => x.Id == response.ResultId).FirstOrDefault();
            //if not present in select samples' result
            if (ItemToUpdate is null)
            {
                //another sample might be selected. Look in all loaded results
                ItemToUpdate = AllResultData.Where(x => x.Id == response.ResultId).FirstOrDefault();
                // Return if not present
                if (ItemToUpdate is null) return;
            }

            //update UI
            ItemToUpdate.Result = response.Result;
            ItemToUpdate.ReferenceCode = response.ReferenceCode;
            ItemToUpdate.StatusIconId = response.StatusId;
            //update sample icon to processing
            var sample = RequestData.Find(x => x.Cin == response.Cin);
            sample.StatusIconId = 6; // 6 is processing
            //refresh UI
            RequestDataRefreshed?.Invoke(this, EventArgs.Empty);
        }

        private void UpdateUiOnAddingReflexTests
            (List<UpdatedResultAndStatusModel> sampleResultAndResultStatus, string cin)
        {
            if (sampleResultAndResultStatus is null) { return; }

            //iterate the response
            foreach (var item in sampleResultAndResultStatus)
            {
                //look for the presence of result
                var result = SelectedResultData.FirstOrDefault((r) => r.Id == item.ResultId);
                if (result != null)
                {
                    result.Result = item.Result;
                    result.ReferenceCode = item.ReferenceCode;
                    result.StatusIconId = item.StatusId;
                }
                else
                {
                    //add test that are not present currently
                    SelectedResultData.Add(new ResultModel()
                    {
                        Id = item.ResultId,
                        Cin = item.Cin,
                        Test = item.TestName,
                        Result = item.Result,
                        ReferenceCode = item.ReferenceCode,
                        StatusIconId = item.StatusId,
                        Unit = item.Unit
                    });
                    AllResultData.Add(new ResultModel()
                    {
                        Id = item.ResultId,
                        Cin = item.Cin,
                        Test = item.TestName,
                        Result = item.Result,
                        ReferenceCode = item.ReferenceCode,
                        StatusIconId = item.StatusId,
                        Unit = item.Unit
                    });
                }
            }

            //refresh ui
            RequestDataRefreshed?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// updates UI after sample is rejected.
        /// </summary>
        /// <param name="statusUpdateData">model returned by datalayer on rejecting sample.</param>
        private void UpdateUiOnSampleRejectionOrRejectionCancellation(SampleAndResultStatusAndResultModel statusUpdateData)
        {
            //find the sample rejected.
            var sample = RequestData.Find(x => x.Cin == statusUpdateData.SampleData.Cin);
            switch (sample)
            {
                case null:
                    return;
                default:
                    //update status Id and Icon of sample.
                    sample.StatusIconId = statusUpdateData.SampleData.StatusId;
                    //Find the sample results
                    var resultData = AllResultData.Where(x => x.Cin == statusUpdateData.SampleData.Cin);
                    //update them
                    foreach (var resultRecord in resultData)
                    {
                        var newData = statusUpdateData.ResultStatus.Find(x => x.ResultId == resultRecord.Id);
                        if (newData != null)
                        {
                            resultRecord.Result = newData.Result;
                            resultRecord.StatusIconId = newData.StatusId;
                            resultRecord.ReferenceCode = newData.ReferenceCode;
                        };
                    }
                    //refresh UI
                    RequestDataRefreshed?.Invoke(this, EventArgs.Empty);
                    break;
            }

        }
        private async void UpdateDatabaseResults(object sender, ListChangedEventArgs e)
        {
            //detect when a result is modified.
            if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                var testData = SelectedResultData.ElementAt(e.NewIndex);
                await InsertUpdateResultByIdAsync(testData.Result, testData.Id, testData.StatusIconId);
            }
        }
        private async Task InsertUpdateResultByIdAsync(string result, int resultId, int testStatus)
        {
            try
            {
                var response = await _resultDataAccess.InsertUpdateResultByResultIdAsync(resultId, result, testStatus, _authorizeDetail.UserId);
                UpdateUiOnResultEntry(response);
            }
            catch (Exception ex)
            {
                //remove the result from UI since it was not saved.
                foreach (var item in SelectedResultData)
                {
                    if (item.Id == resultId)
                    {
                        //Unsubscribe from event to avoid a listchange fire for this change
                        SelectedResultData.ListChanged -= UpdateDatabaseResults;
                        //if the result is not validated... set current result to null
                        if (item.StatusIconId != 5) item.Result = null;
                        //subscribe again
                        SelectedResultData.ListChanged += UpdateDatabaseResults;
                    }
                }
                PushingMessages?.Invoke(this, ex.Message);
            }
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
        private List<Model.CodifiedResultsModel> GetCodifiedPhrasesForIds(string[] idsCodifiedPhrase)
        {
            var returnList = new List<Model.CodifiedResultsModel>();
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

            //AllCodifiedPhrases.Add(new CodifiedResultsModel() { Id = 1, CodifiedValue = "POSITIVE" });
            //AllCodifiedPhrases.Add(new CodifiedResultsModel() { Id = 2, CodifiedValue = "NEGATIVE" });
            //AllCodifiedPhrases.Add(new CodifiedResultsModel() { Id = 3, CodifiedValue = "NOT DETECTED" });
            //AllCodifiedPhrases.Add(new CodifiedResultsModel() { Id = 4, CodifiedValue = "DETECTED" });

            #endregion
        }

        private async void FetchAllCodifiedData(object sender, EventArgs e)
        {
            try
            {
                var codifiedPhrases = await _staticDataDataAccess.GetAllCodifiedValuesAsync();
                AllCodifiedPhrases = _mapper.Map<List<Model.CodifiedResultsModel>>(codifiedPhrases);
            }
            catch (Exception ex)
            {
                PushingMessages?.Invoke(this, ex.Message);
            }
        }
        private int GetSelectedStatusIdOrDefault()
        {
            //declare a variable to hold the selected statusId
            int selectedStatusId;

            //Check whether the selected status is null...
            if (SelectedStatus is null)
            {
                //assign the Id as 4, which corresponds to the ToValidate status.
                selectedStatusId = 0;
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
                RequestData.Add(_mapper.Map<RequestSampleModel>(item));
            }

            //if TestResultData is null return
            if (worklist.TestResultsData is null)
            {
                return;
            }

            //map out new result data
            foreach (var item in worklist.TestResultsData)
            {
                AllResultData.Add(_mapper.Map<ResultModel>(item));
            }

            //notify UI that data has refreshed, so that UI knows to refresh datagrids
            RequestDataRefreshed?.Invoke(this, EventArgs.Empty);
        }

        public async Task RejectTestAsync(ResultModel testToReject, int commentListId)
        {
            try
            {
                // get the actual commentId and user Id to pass in
                var output = await _resultDataAccess.RejectTestByResultId
                    (testToReject.Id, testToReject.Cin, commentListId, _authorizeDetail.UserId);

                var mappedData = _mapper.Map<SampleAndResultStatusAndResultModel>(output);
                //updateUI
                UpdateUiOnSampleRejectionOrRejectionCancellation(mappedData);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task CancelTestRejection(ResultModel testData)
        {
            try
            {
                var output = await _resultDataAccess.CancelTestRejectionByResultId(testData.Id, 1);
                var mappedData = _mapper.Map<SampleAndResultStatusAndResultModel>(output);
                //updateUI
                UpdateUiOnSampleRejectionOrRejectionCancellation(mappedData);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// checks whether it is okay to cancel sample rejection.
        /// </summary>
        /// <param name="sample"> The request sample model of the sample to reject</param>
        /// <returns>True if it is okay to cancel sample rejection</returns>
        public bool CanCancelSampleRejection(RequestSampleModel sample)
        {
            //if sample is marked as rejected, it is okay to cancel sample rejection
            if (sample.StatusIconId == 7) return true;

            //get all the tests for sample
            var results = AllResultData.Where(x => x.Cin == sample.Cin);
            //if no tests exist, cannot cancel rejection.
            if (results is null) return false;

            //check whether any test is rejected.
            foreach (var item in results)
            {
                if (item.StatusIconId == 7)
                {
                    //if rejected test exist, can cancel rejection
                    return true;
                }
            }

            //if no tests rejected, cannot cancel rejection
            return false;
        }

        /// <summary>
        /// evaluate whether the specific test be rejected
        /// </summary>
        /// <param name="resultToEvaluateForRejection"></param>
        /// <returns></returns>
        public bool CanCancelTestRejection(ResultModel resultToEvaluateForRejection)
        {
            return resultToEvaluateForRejection.StatusIconId == 7;
        }

        public async Task<dynamic> GetResultHistoryAsync(ResultModel testRecord)
        {
            try
            {
                return await _resultDataAccess.GetResultHistoryAync(testRecord.Id, testRecord.AnalysisRequestId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// returns true if the test status is 5 (Validated)
        /// </summary>
        /// <param name="testData">Result Model of selected test data</param>
        /// <returns>return true if the sample is validated, otherwise returns false</returns>
        public bool CanCancelTestValidation(ResultModel testData)
        {
            return testData.StatusIconId == 5;
        }

        public async Task CancelTestValidation(ResultModel testData)
        {
            try
            {
                var result = await _resultDataAccess.CancelResultValidation(testData.Id, testData.Cin, _authorizeDetail.UserId);
                var mappedData = _mapper.Map<SampleAndResultStatusAndResultModel>(result);
                //updateUI, the following method can be used to Update UI after cancelling test rejection. Refactoring required
                UpdateUiOnSampleRejectionOrRejectionCancellation(mappedData);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ResultModel> GetResultData(string cin)
        {
            return AllResultData.FindAll((x) => x.Cin == cin).ToList();
        }

        #endregion

    }
}
