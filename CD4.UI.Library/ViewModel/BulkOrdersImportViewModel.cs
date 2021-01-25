using AutoMapper;
using CD4.DataLibrary.DataAccess;
using CD4.UI.Library.Model;
using DevExpress.XtraEditors;
using Ganss.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public class BulkOrdersImportViewModel : INotifyPropertyChanged, IBulkOrdersImportViewModel
    {
        #region Private Properties

        private string testToAdd;
        private string receiptNumber;
        private string excelFilePath;
        private bool loadingAnimationVisible;
        private bool errorsPanelVisible;
        private readonly IBulkOrdersImportDataAccess _ordersImportDataAccess;
        private readonly IAnalysisRequestDataAccess _requestDataAccess;
        private readonly IMapper _mapper;
        private readonly AuthorizeDetailEventArgs _authorizeDetail;

        #endregion

        private event EventHandler InitializeData;
        private event EventHandler InitializeExcelFileRead;

        #region Default Constructor
        public BulkOrdersImportViewModel(IBulkOrdersImportDataAccess ordersImportDataAccess,
            IAnalysisRequestDataAccess requestDataAccess,
            IMapper mapper,
            AuthorizeDetailEventArgs authorizeDetail)
        {
            Islands = new BindingList<IslandModel>();
            Sites = new List<SitesModel>();
            AllAtollsWithCorrespondingIsland = new List<AtollIslandModel>();
            Nationalities = new List<CountryModel>();
            AllTestsData = new List<ProfilesAndTestsDatasourceOeModel>();
            AddedTests = new BindingList<TestModel>();
            GenderList = new List<GenderModel>();
            BulkDataList = new BindingList<BulkSchemaModel>();
            ClinicalDetails = new List<ClinicalDetailsOrderEntryModel>();
            ErrorMessages = new List<string>();
            _ordersImportDataAccess = ordersImportDataAccess;
            _requestDataAccess = requestDataAccess;
            _mapper = mapper;
            this._authorizeDetail = authorizeDetail;
            LoadingAnimationVisible = false;
            InitializeData += BulkOrdersImportViewModel_InitializeData;
            InitializeExcelFileRead += BulkOrdersImportViewModel_InitializeExcelFileRead;
            InitializeData?.Invoke(this, EventArgs.Empty);
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

        public string ReceiptNumber
        {
            get => receiptNumber; set
            {
                if (receiptNumber == value) { return; }
                receiptNumber = value;
                OnPropertyChanged();
            }
        }
        public string TestToAdd
        {
            get => testToAdd; set
            {
                if (testToAdd == value) { return; }
                testToAdd = value;
                OnPropertyChanged();
            }
        }
        public string ExcelFilePath
        {
            get => excelFilePath; set
            {
                if (excelFilePath == value) { return; }
                excelFilePath = value;
                OnPropertyChanged();
                InitializeExcelFileRead?.Invoke(this, EventArgs.Empty);
            }
        }

        private List<AtollIslandModel> AllAtollsWithCorrespondingIsland { get; set; }
        public BindingList<IslandModel> Islands { get; set; }
        public List<SitesModel> Sites { get; set; }
        public List<CountryModel> Nationalities { get; set; }
        public BindingList<TestModel> AddedTests { get; set; }
        public List<ProfilesAndTestsDatasourceOeModel> AllTestsData { get; set; }
        public BindingList<BulkSchemaModel> BulkDataList { get; set; }
        public List<GenderModel> GenderList { get; set; }
        public List<ClinicalDetailsOrderEntryModel> ClinicalDetails { get; set; }
        public List<string> ErrorMessages { get; set; }
        public bool LoadingAnimationVisible
        {
            get => loadingAnimationVisible; set
            {
                loadingAnimationVisible = value;
                OnPropertyChanged();
            }
        }
        public string ButtonErrorsCountlabel { get => $"View Errors [ {ErrorMessages.Count} ]"; }
        public bool ButtonErrorsCountEnabled
        {
            get
            {
                return ErrorMessages.Count > 0;
            }
        }
        public bool ErrorsPanelVisible
        {
            get => errorsPanelVisible; set
            {
                errorsPanelVisible = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(MainPanelVisible));
            }
        }

        public bool MainPanelVisible
        {
            get
            {
                return !ErrorsPanelVisible;
            }

        }

        #endregion

        #region Private Methods

        private async void BulkOrdersImportViewModel_InitializeExcelFileRead(object sender, EventArgs e)
        {
            try
            {
                LoadingAnimationVisible = true;
                await LoadExcelFile();

                ErrorMessages.Clear();

                await Task.Run(() =>
                {
                    CalculateHash();
                    CheckForDublicates();
                    ValidateData();

                    SetUnderlyingIds();
                });

                OnPropertyChanged(nameof(ButtonErrorsCountlabel));
                OnPropertyChanged(nameof(ButtonErrorsCountEnabled));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            finally
            {
                LoadingAnimationVisible = false;
            }

        }

        private async void BulkOrdersImportViewModel_InitializeData(object sender, EventArgs e)
        {
            LoadingAnimationVisible = true;
            try
            {
                var results = await _ordersImportDataAccess.GetAllStaticDataForBulkImport();
                //map them out
                await Task.Run(() =>
                {
                    GenderList.AddRange(_mapper.Map<List<GenderModel>>(results.Genders));
                    AllAtollsWithCorrespondingIsland.AddRange(_mapper.Map<List<AtollIslandModel>>(results.AtollsAndIslands));
                    Sites.AddRange(_mapper.Map<List<SitesModel>>(results.Sites));
                    Nationalities.AddRange(_mapper.Map<List<CountryModel>>(results.Countries));
                    ClinicalDetails.AddRange(_mapper.Map<List<ClinicalDetailsOrderEntryModel>>(results.ClinicalDetails));
                    AllTestsData.AddRange(_mapper.Map<List<ProfilesAndTestsDatasourceOeModel>>(results.Tests));
                });

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            finally
            {
                LoadingAnimationVisible = false;
            }
        }

        /// <summary>
        /// combines nid/pp and sample collection date and calculates a hash
        /// This is used to check whether the record has already been imported.
        /// </summary>
        private void CalculateHash()
        {
            foreach (var item in BulkDataList)
            {
                item.Hash = (item.NidPp, item.SampleCollectedDateTime).GetHashCode();
            }
        }
        private void CheckForDublicates()
        {
            foreach (var item in BulkDataList)
            {
                var data = BulkDataList.Where((x) => x.NidPp == item.NidPp && x.SampleCollectedDateTime == item.SampleCollectedDateTime);
                item.SetDublicateStatus(data?.Count() > 1);

            }
        }

        private void ValidateData()
        {

        }
        private void SetUnderlyingIds()
        {

            foreach (var item in BulkDataList)
            {

                //verify that none of the required columns are null
                if (item.Gender is null || item.Nationality is null || item.Atoll is null || item.Island is null || item.SampleSite is null)
                {
                    ErrorMessages.Add($"Required data not provided for record: {item.NidPp} | {item.Fullname}.\n\t" +
                        $"Gender: {item.Gender}\n\t" +
                        $"Nationality: {item.Nationality}\n\t" +
                        $"Atoll: {item.Atoll}\n\t" +
                        $"Island: {item.Island}\n\t" +
                        $"Sample Site: {item.SampleSite}");
                    item.IsValidData = false;
                    continue;
                }

                //get gender Id
                var gender = GenderList.Find((x) => x.Gender.Trim().ToLower() == item.Gender.Trim().ToLower());
                if (gender is null)
                {
                    ErrorMessages.Add(BuildErrorMessage(nameof(BulkSchemaModel.Gender), item.Gender));
                    item.IsValidData = false; continue;
                }
                item.GenderId = gender.Id;

                //get nationalityId
                var nationality = Nationalities.Find((x) => x.Country.Trim().ToLower() == item.Nationality.Trim().ToLower());
                if (nationality is null)
                {
                    ErrorMessages.Add(BuildErrorMessage(nameof(BulkSchemaModel.Nationality), item.Nationality));
                    item.IsValidData = false; continue;
                }
                item.NationalityId = nationality.Id;

                //get atollIslandId
                var atollAndIsland = AllAtollsWithCorrespondingIsland.Find((x) =>
                    x.Island.Trim().ToLower() == item.Island.Trim().ToLower() &&
                    x.Atoll.Trim().ToLower() == item.Atoll.Trim().ToLower()
                );

                if (atollAndIsland is null)
                {
                    ErrorMessages.Add(BuildErrorMessage($"{nameof(BulkSchemaModel.Atoll)} and {nameof(BulkSchemaModel.Island)}", $"{item.Atoll} | {item.Island}"));
                    item.IsValidData = false; continue;
                }
                item.AtollIslandId = atollAndIsland.Id;

                //SiteId
                var site = Sites.Find((x) => x.Site.Trim().ToLower() == item.SampleSite.Trim().ToLower());
                if (site is null)
                {
                    ErrorMessages.Add(BuildErrorMessage(nameof(BulkSchemaModel.SampleSite), item.SampleSite));
                    item.IsValidData = false; continue;
                }
                item.SiteId = site.Id;


            }
        }

        private string BuildErrorMessage(string propertyName, string propertyValue)
        {
            return $"Specified data cannot be found. {propertyName}: {propertyValue}";
        }

        private async Task LoadExcelFile()
        {
            var excelData = await Task.Run(async () =>
           {
               return await new ExcelMapper().FetchAsync<BulkSchemaModel>(ExcelFilePath, 0);
           });
            BulkDataList.Clear();

            if (excelData != null)
            {
                if (excelData.ToList().Count < 1) { return; }
                foreach (var item in excelData)
                {
                    BulkDataList.Add(item);
                }
            }
        }
        private async Task ConfirmAnalysisRequest(AnalysisRequestDataModel request)
        {
            var data = new DataLibrary.Models.AnalysisRequestDataModel()
            {
                EpisodeNumber = request.EpisodeNumber,
                Cin = request.Cin,
                SiteId = request.SelectedSiteId,
                SampleCollectionDate = request.SampleCollectionDate,
                SampleReceivedDate = request.SampleReceivedDate,
                NationalIdPassport = request.NationalIdPassport,
                Fullname = request.Fullname,
                GenderId = request.GenderId,
                Birthdate = request.Birthdate,
                Age = SetAge(request.Birthdate),
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                AtollId = request.AtollId,
                CountryId = request.CountryId,
                ClinicalDetails = new List<DataLibrary.Models.ClinicalDetailsSelectionModel>(),
                Tests = new List<DataLibrary.Models.TestsModel>()
            };

            data.ClinicalDetails = _mapper.Map<List<DataLibrary.Models.ClinicalDetailsSelectionModel>>(request.ClinicalDetails);
            data.Tests = _mapper.Map<List<DataLibrary.Models.TestsModel>>(request.Tests);
            await _requestDataAccess.ConfirmRequestAsync(data, _authorizeDetail.UserId);
        }
        private string SetAge(DateTime birthdate)
        {
            return DateTimeExtensions.ToAgeString(birthdate);
        }
        private List<AnalysisRequestDataModel> BulkSchemaModelToAnalysisRequestModels(List<BulkSchemaModel> bulkAnalysisRequests)
        {
            var analysisRequest = new List<AnalysisRequestDataModel>();

            foreach (var item in bulkAnalysisRequests)
            {
                analysisRequest.Add(new AnalysisRequestDataModel()
                {
                    /*NOT INCLUDED
                        Cin: generated later
                        Sample received date time: when sample barcode is read
                     */
                    SelectedSiteId = item.SiteId,
                    SampleCollectionDate = item.SampleCollectedDateTime,

                    NationalIdPassport = item.NidPp,
                    Fullname = item.Fullname,
                    GenderId = item.GenderId,
                    Age = "11", //handle this better
                    PhoneNumber = item.PhoneNumber.ToString(),
                    Birthdate = item.Birthdate,
                    Address = item.Address,
                    AtollId = item.AtollIslandId,
                    CountryId = item.NationalityId,

                    //clinical details
                    //tests

                    ClinicalDetails = new List<ClinicalDetailsOrderEntryModel>(),
                    Tests = new List<TestModel>(),
                    EpisodeNumber = this.ReceiptNumber
                });

                foreach (var detail in this.ClinicalDetails)
                {
                    if (detail.ClinicalDetail == "Breathing Difficulty")
                    {
                    }

                    switch (detail.ClinicalDetail)
                    {
                        case "Breathing Difficulty":
                            detail.IsSelected = item.BreathingDifficulty;
                            break;
                        case "Cough":
                            detail.IsSelected = item.Cough;
                            break;
                        case "Fever":
                            detail.IsSelected = item.Fever;
                            break;
                        case "Runny Nose":
                            detail.IsSelected = item.RunnyNose;
                            break;
                        case "Travel History":
                            detail.IsSelected = item.TravelHistory;
                            break;
                        default:
                            break;
                    }
                }
            }

            return analysisRequest;

        }
        private async Task<ProfilesAndTestsDatasourceOeModel> GetSelectedTestOrProfileByDescriptionAsync(string testDescription)
        {
            return await Task.Run(() =>
            {
                return AllTestsData.SingleOrDefault(t => t.Description == testDescription);
            });
        }

        private async Task AddTestListToRequestAsync(List<TestModel> testModelList)
        {
            if (testModelList is null) throw new ArgumentNullException(nameof(testModelList));

            foreach (var test in testModelList)
            {
                await AddSingleTestToRequestAsync(test);
            }
        }

        private async Task AddSingleTestToRequestAsync(TestModel test)
        {
            if (test is null) return;
            if (await IsTestPresentOnRequest(test.Description) == false)
            {
                Debug.WriteLine("Test is not present on AR! Continuing to add.");
                AddedTests.Add(test);
            }
        }

        private async Task<bool> IsTestPresentOnRequest(string testDescription)
        {
            Debug.WriteLine("Checking whether the test is already added.");
            return await Task.Run(() =>
            {
                return AddedTests.Any((t) => t.Description == testDescription);
            });
        }

        #endregion

        #region Public Methods
        public async Task ManageAddTestToRequestAsync()
        {
            Debug.WriteLine("Called: ManageAddTestToRequestAsync");
            if (TestToAdd is null) return;
            var selectedTest = await GetSelectedTestOrProfileByDescriptionAsync(TestToAdd);
            if (selectedTest is null) return;
            switch (selectedTest.IsProfile)
            {
                case true:
                    Debug.WriteLine("Selected a profile test. Proceeding to add corresponding tests...");
                    await AddTestListToRequestAsync(selectedTest.TestsInProfile);
                    break;
                case false:
                    Debug.WriteLine("Not a profile test. Proceeding...");
                    await AddSingleTestToRequestAsync(selectedTest);
                    break;
                default:
                    throw new Exception("IsProfile parameter must be specified.");
            }

            Debug.WriteLine("Clearing the lookupedit box.");
            TestToAdd = null;
        }
        public async Task ConformUploadSelected(List<BulkSchemaModel> selectedRecordsToImport)
        {
            //handling null parameter
            if (selectedRecordsToImport is null)
            {
                XtraMessageBox.Show("No records selected to import");
                return;
            }

            //if the parameter has no items to upload to database..., return
            if (selectedRecordsToImport.Count == 0)
            {
                XtraMessageBox.Show("No records selected to import");
                return;
            }

            //new up a temp list
            var temp = new List<BulkSchemaModel>();

            //check whether the data selected is not dublicate or invalid
            foreach (var item in selectedRecordsToImport)
            {
                if (item.IsDublicate == false && item.IsValidData == true)
                {
                    //check whether hash exists on database
                    if (!await IsImportedBefore(item))
                    {
                        //if record hash does not exist on database..., add it to temp list
                        temp.Add(item);
                    }
                }
            }

            if (temp.Count == 0)
            {
                XtraMessageBox.Show("Cannot import any of the selected records. " +
                    "The records are either invalid, dublicated or all records have been previously imported.");
                return;
            }

            //get a list of data layer model to call to data layer
            List<AnalysisRequestDataModel> analysisRequests = BulkSchemaModelToAnalysisRequestModels(temp);

            //confirm analysis requests
            try
            {
                foreach (var request in analysisRequests)
                {
                    //generate a new CIN
                    request.Cin = await _requestDataAccess.GetNextCinSeed();
                    //add selected tests to the request
                    request.Tests.AddRange(AddedTests);
                    await ConfirmAnalysisRequest(request);
                    //call database to get the with Cin to get the request for displaying
                    var bulkDataItem = BulkDataList.FirstOrDefault
                        ((x) => x.NidPp == request.NationalIdPassport && x.SampleCollectedDateTime == request.SampleCollectionDate);
                    if (bulkDataItem != null)
                    {
                        bulkDataItem.Cin = request.Cin;
                    }

                    await _ordersImportDataAccess.InsertHash(bulkDataItem.Hash, request.Cin);
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }
        }

        private async Task<bool> IsImportedBefore(BulkSchemaModel item)
        {
            //look for a cin for the hash
            var cinForHash = await _ordersImportDataAccess.GetCinForImportedHash(item.Hash);
            //if returned cin is null or empty
            if (string.IsNullOrEmpty(cinForHash))
            {
                //not imported before
                return false;
            }
            else
            {
                var bulkDataItem = BulkDataList.FirstOrDefault((x) => x.NidPp == item.NidPp && x.SampleCollectedDateTime == item.SampleCollectedDateTime);
                if (bulkDataItem != null)
                {
                    bulkDataItem.Cin = cinForHash;
                }
                //imported before... update the bulk list to reflect the value
                ErrorMessages.Add($"The record has been imported earlier as {cinForHash}. " +
                    $"Please find the details below.\n\n{JsonConvert.SerializeObject(item, Formatting.Indented)}");

                //XtraMessageBox.Show($"The record has been imported earlier as {cinForHash}. " +
                //            $"Please find the details below.\n\n{JsonConvert.SerializeObject(item, Formatting.Indented)}");
                return true;
            }
        }

        public void ClearErrorMessages()
        {
            ErrorMessages.Clear();
            OnPropertyChanged(nameof(ButtonErrorsCountlabel));
            OnPropertyChanged(nameof(ButtonErrorsCountEnabled));
        }

        #endregion
    }
}
