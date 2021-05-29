using AutoMapper;
using CD4.DataLibrary.DataAccess;
using CD4.UI.Library.Helpers;
using CD4.UI.Library.Model;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public class HmsLinkViewModel : ViewModelBase, IHmsLinkViewModel
    {
        private readonly IGlobalSettingsHelper _globalSettingsHelper;
        private readonly IHmsLinkDataAccess _hmsLinkDataAccess;
        private readonly IStaticDataDataAccess _staticData;
        private readonly IDisciplineDataAccess _disciplineDataAccess;
        private readonly ISampleTypeDataAccess _sampleTypeDataAccess;
        private readonly IAnalysisRequestDataAccess _analysisRequestDataAccess;
        private readonly IMapper _mapper;
        private bool loadingStaticData;
        private bool isRequestPriority;

        public event EventHandler InitializeHmsLink;
        public HmsLinkViewModel(IGlobalSettingsHelper globalSettingsHelper,
            IHmsLinkDataAccess hmsLinkDataAccess,
            IStaticDataDataAccess staticDataAccess,
            IDisciplineDataAccess disciplineDataAccess,
            ISampleTypeDataAccess sampleTypeDataAccess,
            IAnalysisRequestDataAccess analysisRequestDataAccess,
            IMapper mapper)
        {
            _globalSettingsHelper = globalSettingsHelper;
            _hmsLinkDataAccess = hmsLinkDataAccess;
            _staticData = staticDataAccess;
            _disciplineDataAccess = disciplineDataAccess;
            _sampleTypeDataAccess = sampleTypeDataAccess;
            _analysisRequestDataAccess = analysisRequestDataAccess;
            _mapper = mapper;
            AnalysisRequests = new BindingList<HmsLinkDataModel>();
            AllCountries = new List<CountryModel>();
            AllGender = new List<GenderModel>();
            AllAtollsWithCorrespondingIsland = new List<AtollIslandModel>();
            Sites = new List<SitesModel>();
            Patient = new BindingList<PatientModel>();
            AllTestsData = new List<ProfilesAndTestsDatasourceOeModel>();
            AllDisciplines = new List<DisciplineModel>();
            AllSampleTypes = new List<SampleTypeModel>();
            AllBillingMapData = new List<BillingTestMappingModel>();

            InitializeHmsLink += OnInitializeStaticDataAsync;
            InitializeHmsLink?.Invoke(this, EventArgs.Empty);
        }

        private async void OnInitializeStaticDataAsync
            (object sender, EventArgs e)
        {
            try
            {
                LoadingStaticDataStatus = true;

                await LoadAllCountriesAsync();
                await LoadAllSitesAsync();
                await LoadAllGenderAsync();
                await LoadAllAtollsAndIslandsAsync();
                await LoadAllTestsAsync();
                await LoadAllDisciplinesAsync();
                await LoadAllSampleTypes();
                //need the billing map
                await LoadAllBillingTestCodeMappings();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error loading static data.\n{ex.Message}\n{ex.StackTrace}");
            }
            finally
            {
                LoadingStaticDataStatus = false;
            }


        }

        public BindingList<PatientModel> Patient { get; set; }
        public BindingList<HmsLinkDataModel> AnalysisRequests { get; set; }
        public List<CountryModel> AllCountries { get; set; }
        public List<GenderModel> AllGender { get; set; }
        private List<AtollIslandModel> AllAtollsWithCorrespondingIsland { get; set; }
        public List<SitesModel> Sites { get; set; }
        public List<ProfilesAndTestsDatasourceOeModel> AllTestsData { get; set; }
        public List<DisciplineModel> AllDisciplines { get; set; }
        public List<SampleTypeModel> AllSampleTypes { get; set; }
        public List<BillingTestMappingModel> AllBillingMapData { get; set; }
        public bool IsRequestPriority
        {
            get => isRequestPriority; set
            {
                isRequestPriority = value;
                Debug.WriteLine("STAT Request? : " + value);
                OnPropertyChanged();
            }
        }

        public bool LoadingStaticDataStatus
        {
            get => loadingStaticData; set
            {
                loadingStaticData = value;
                OnPropertyChanged();
            }
        }

        private async Task LoadAllBillingTestCodeMappings()
        {
            AllBillingMapData.Clear();
            var billingCodesMap = await _staticData.GetBillingTestCodeMappings();
            var mapped = _mapper.Map<List<BillingTestMappingModel>>(billingCodesMap);
            AllBillingMapData.AddRange(mapped);
        }


        private async Task LoadAllSampleTypes()
        {
            AllSampleTypes.Clear();
            var sampleTypes = await _sampleTypeDataAccess.GetAllDSampleTypesAsync();
            var mapped = _mapper.Map<List<SampleTypeModel>>(sampleTypes);
            AllSampleTypes.AddRange(mapped);
        }

        private async Task LoadAllDisciplinesAsync()
        {
            AllDisciplines.Clear();
            var disciplines = await _disciplineDataAccess.GetAllDisciplinesAsync();
            var mapped = _mapper.Map<List<DisciplineModel>>(disciplines);
            AllDisciplines.AddRange(mapped);
        }

        private async Task LoadAllTestsAsync()
        {
            var results = await _staticData.GetAllTestsAsync();
            foreach (var item in results)
            {
                this.AllTestsData.Add(_mapper.Map<ProfilesAndTestsDatasourceOeModel>(item));
            }
        }

        private async Task LoadAllCountriesAsync()
        {

            var results = await _staticData.GetAllCountriesAsync();

            foreach (var item in results)
            {
                this.AllCountries.Add(_mapper.Map<CountryModel>(item));
            }

        }

        private async Task LoadAllAtollsAndIslandsAsync()
        {
            var results = await _staticData.GetAllAtollsAndIslandsAsync();
            foreach (var item in results)
            {
                this.AllAtollsWithCorrespondingIsland.Add(_mapper.Map<AtollIslandModel>(item));
            }
        }

        private async Task LoadAllGenderAsync()
        {

            var results = await _staticData.GetAllGenderAsync();
            foreach (var item in results)
            {
                this.AllGender.Add(_mapper.Map<GenderModel>(item));
            }

        }

        private async Task LoadAllSitesAsync()
        {
            var results = await _staticData.GetAllSitesAsync();
            foreach (var item in results)
            {
                this.Sites.Add(_mapper.Map<SitesModel>(item));
            }
        }

        public async Task FetchAnalysisRequestForMemoNumberAsync(int episodeNumber)
        {
            try
            {
#if DEBUG
                var requestData = await _hmsLinkDataAccess.
                    GetAnalysisRequestDataByEpisodeNumberMock(episodeNumber, _globalSettingsHelper.Settings.HmsLinkQuery);
#else
                var requestData = await _hmsLinkDataAccess.
                    GetAnalysisRequestDataByEpisodeNumber(episodeNumber, _globalSettingsHelper.Settings.HmsLinkQuery);
#endif
                var mappedArData = _mapper.Map<List<HmsLinkDataModel>>(requestData);
                DisplayDataOnUI(mappedArData);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void DisplayDataOnUI(List<HmsLinkDataModel> mappedArData)
        {
            Patient.Clear();
            AnalysisRequests.Clear();
            foreach (var item in mappedArData)
            {
                //add the patient if not present already
                var patient = Patient.Where((x) => x.InstituteAssignedPatientId.ToString() == item.PatientId).FirstOrDefault();
                if (patient is null)
                {
                    var isPatientIdLong = long.TryParse(item.PatientId, out var parsedPid);
                    var patientToAdd = new PatientModel()
                    {
                        NidPp = item.NidPp,
                        Fullname = item.FullName,
                        Gender = item.Gender,
                        Birthdate = item.Birthdate.Value,
                        Address = item.Address,
                    };

                    var atollIslandModel = GetAtoll(item.RegAtollId, item.RegIslandId);
                    if (atollIslandModel != null)
                    {
                        patientToAdd.Atoll = atollIslandModel.Atoll;
                        patientToAdd.Island = atollIslandModel.Island;
                    }

                    if (isPatientIdLong) { patientToAdd.InstituteAssignedPatientId = parsedPid; }
                    Patient.Add(patientToAdd);
                }
                //Add the ar
                AnalysisRequests.Add(item);
            }
        }


        private AtollIslandModel GetAtoll(int regAtollId, int regIslandId)
        {
            var atollIslandId = $"{1000 + regAtollId}{regIslandId}";
            var atollAndIsland = AllAtollsWithCorrespondingIsland
                .Where((x) => x.Id.ToString() == atollIslandId.Trim()).FirstOrDefault();
            return atollAndIsland;
        }

        public void ResetUi()
        {
            Patient.Clear();
            AnalysisRequests.Clear();
            IsRequestPriority = false;
        }

        public async Task<bool> ConfirmAnalysisRequest(List<HmsLinkDataModel> dataToConfirm, int loggedInUserId)
        {

            /*
             * Request Fileds
             * ===============
             * Cin : GENERATE the SIDs
             * SiteId: Auto set as per IP Address, -- set up an array on gloabl config
             * Collected Date: TODAY
             * Accepted date: Null???
             * 
             * patient details
             * ================
             * Nid/pp
             * fullname
             * Gender as per CD4
             * gender Id
             * Age
             * PhoneNumber
             * Birthdate
             * Address
             * Atoll
             * island
             * Atollid
             * country
             * CountryId
             * NOTE: make nationality as NA?
             * InstituteAssignedPatientId
             * 
             * Clinical Details, Tests, Episode Number
             * =======================================
             * Clinical details: null
             * Tests: Added for generated SID
             * Episode Number
             */

            var hmsLinkData = dataToConfirm.FirstOrDefault();
            var patient = Patient.FirstOrDefault();
            var gender = AllGender.Find((x) => x.Gender.ToLower().StartsWith(hmsLinkData.Gender.Trim().ToLower()));

            //generate sample
            var samples = await GenerateSamplesAsync(dataToConfirm);
            if (samples is null) { throw new Exception("No samples generated. Make sure to select the required services."); }
            if (samples.Count == 0) { throw new Exception("No samples generated. Make sure to select the required services."); }
            foreach (var sample in samples)
            {
                var analysisRequestModel = new AnalysisRequestDataModel()
                {
                    Cin  = sample.Cin,
                    SampleCollectionDate = DateTimeOffset.Now,

                    NationalIdPassport = hmsLinkData.NidPp,
                    Fullname = hmsLinkData.FullName,
                    GenderId = gender.Id,
                    Age = DateTimeExtensions.ToAgeString((DateTime)hmsLinkData.Birthdate),
                    PhoneNumber = patient.PhoneNumber,
                    Birthdate = patient.Birthdate,
                    Address = patient.Address,
                    AtollId = GetAtoll(hmsLinkData.RegAtollId, hmsLinkData.RegIslandId).Id,
                    CountryId = 1,

                    ClinicalDetails = new List<ClinicalDetailsOrderEntryModel>(),
                    Tests = sample.Tests,
                    EpisodeNumber = hmsLinkData.EpisodeNumber.ToString()
                };

                var mapped = _mapper.Map<DataLibrary.Models.AnalysisRequestDataModel>(analysisRequestModel);
                mapped.SiteId = 1;
                await _analysisRequestDataAccess
                    .ConfirmRequestAsync(mapped, loggedInUserId, IsRequestPriority);
            }

            return true;
        }

        private async Task<List<SampleWithTestsModel>> GenerateSamplesAsync(List<HmsLinkDataModel> dataToConfirm)
        {
            //get the seed without prefix
            var seed = await _analysisRequestDataAccess.GetNextCinSeedWithoutPrefix();
            var samples = new List<SampleWithTestsModel>();
            foreach (var item in dataToConfirm)
            {
                //get test Id for billing Id
                var tests = GetTestsFromBillingTestCode(item.ItemCode);

                //determine SID
                var generatedSamples = GenerateSidsForTests(tests, seed);


                //Is SID present?... 
                //  NO: Create SID, add the test if the test does not exist already
                //  YES: add the test model to that

                foreach (var s in generatedSamples)
                {
                    var isSampleIdPresent = IsSampleIdPresent(samples, s.Cin);
                    //if sample is not present. add it
                    if (!isSampleIdPresent) { samples.Add(s); continue; }

                    //if sample is present... add non-existing tests to the sample
                    //get the sample
                    var sample = samples.Find((x) => x.Cin == s.Cin);
                    foreach (var test in s.Tests)
                    {
                        var isTesPresent = IsTestPresent(test, sample);
                        if (!isTesPresent) { sample.Tests.Add(test); }
                    }
                }
            }

            return samples;
        }

        private bool IsTestPresent(TestModel test, SampleWithTestsModel sample)
        {
            foreach (var item in sample.Tests)
            {
                if (item.Id == test.Id) { return true; }
            }
            return false;

        }

        private List<SampleWithTestsModel>
            GenerateSidsForTests(List<ProfilesAndTestsDatasourceOeModel> tests, string seed)
        {
            var samplesWithTests = new List<SampleWithTestsModel>();

            foreach (var item in tests)
            {
                //get sample type && get discipline
                var discipline = GetDisciplineByDescription(item.Discipline);
                var sampleType = AllSampleTypes.Where((x) => x.Description == item.SampleType).FirstOrDefault();

                //construct sample ID
                var sid = $"{discipline.Code}{sampleType.Code}{seed}{item.Code}";

                //check whether the sid present already
                var isSampleIdPresent = IsSampleIdPresent(samplesWithTests, sid);

                //if present... add tests to the existing sample
                if (isSampleIdPresent)
                {
                    foreach (var sample in samplesWithTests)
                    {
                        if (sample.Cin == sid)
                        {
                            sample.Tests.Add(item);
                            break;
                        }
                    }
                }

                //otherwise create a new sample with the tests 
                var newSample = new SampleWithTestsModel() { Cin = sid };
                newSample.Tests.Add(item);

                samplesWithTests.Add(newSample);
            }

            return samplesWithTests;
        }

        private bool IsSampleIdPresent
            (List<SampleWithTestsModel> samplesWithTests, string sid)
        {
            foreach (var item in samplesWithTests)
            {
                if (item.Cin == sid) { return true; }
            }
            return false;
        }

        private DisciplineModel GetDisciplineByDescription(string discipline)
        {
            var disciplineModel = AllDisciplines
                .Where((x) => x.Discipline == discipline).FirstOrDefault();
            if (disciplineModel is null) { return new DisciplineModel(); }
            return disciplineModel;
        }

        private List<ProfilesAndTestsDatasourceOeModel> GetTestsFromBillingTestCode(int itemCode)
        {
            var testIds = AllBillingMapData.Where((x) => x.BillingTestId == itemCode.ToString());
            if (testIds is null) return new List<ProfilesAndTestsDatasourceOeModel>();

            var tests = new List<ProfilesAndTestsDatasourceOeModel>();
            foreach (var item in testIds)
            {
                var test = AllTestsData.Where((x) => x.Id == item.TestId).FirstOrDefault();
                if (test is null) { continue; }
                tests.Add(test);
            }

            return tests;
        }
    }
}
