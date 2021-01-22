using AutoMapper;
using CD4.DataLibrary.DataAccess;
using CD4.UI.Library.Model;
using DevExpress.XtraEditors;
using Ganss.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private string address;
        private string selectedAtoll;
        private string selectedIsland;
        private int selectedSiteId;
        private string excelFilePath;
        private bool loadingAnimationVisible;
        private readonly IBulkOrdersImportDataAccess _ordersImportDataAccess;
        private readonly IAnalysisRequestDataAccess _requestDataAccess;
        private readonly IMapper _mapper;

        #endregion

        private event EventHandler InitializeData;
        private event EventHandler InitializeExcelFileRead;

        #region Default Constructor
        public BulkOrdersImportViewModel(IBulkOrdersImportDataAccess ordersImportDataAccess,
            IAnalysisRequestDataAccess requestDataAccess,
            IMapper mapper)
        {
            Islands = new BindingList<IslandModel>();
            Sites = new List<SitesModel>();
            AllAtollsWithCorrespondingIsland = new List<AtollIslandModel>();
            Nationalities = new List<CountryModel>();
            AllTestsData = new List<ProfilesAndTestsDatasourceOeModel>();
            GenderList = new List<GenderModel>();
            BulkDataList = new BindingList<BulkSchemaModel>();
            ClinicalDetails = new List<ClinicalDetailsOrderEntryModel>();
            ErrorMessages = new BindingList<string>();
            _ordersImportDataAccess = ordersImportDataAccess;
            _requestDataAccess = requestDataAccess;
            _mapper = mapper;
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
        public BindingList<string> ErrorMessages { get; set; }
        public bool LoadingAnimationVisible
        {
            get => loadingAnimationVisible; set
            {
                loadingAnimationVisible = value;
                OnPropertyChanged();
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

                await Task.Run(() =>
                {
                    CalculateHash();
                    CheckForDublicates();
                    ValidateData();
                    SetUnderlyingIds();
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
                item.IsDublicate = data?.Count() > 1;

            }
        }

        private void ValidateData()
        {

        }
        private void SetUnderlyingIds()
        {
            ErrorMessages.Clear();

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
        #endregion

        #region Public Methods
        public async Task ConformUploadSelected()
        {
            var temp = new List<BulkSchemaModel>();

            //get a list of data layer model to call to data layer
            List<AnalysisRequestDataModel> analysisRequests = BulkSchemaModelToAnalysisRequestModels(temp);

            //confirm analysis requests
            try
            {
                foreach (var request in analysisRequests)
                {
                    //check whether hash exists on database
                    //confirm if has is new hash
                    //generate a new CIN
                    await ConfirmAnalysisRequest(request);
                    //call database to get the with Cin to get the request for displaying
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Task ConfirmAnalysisRequest(AnalysisRequestDataModel request)
        {
            throw new NotImplementedException();
        }

        private List<AnalysisRequestDataModel> BulkSchemaModelToAnalysisRequestModels(List<BulkSchemaModel> analysisRequests)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
