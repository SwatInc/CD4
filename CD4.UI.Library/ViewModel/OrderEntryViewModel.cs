﻿using AutoMapper;
using CD4.DataLibrary.DataAccess;
using CD4.UI.Library.Model;
using CD4.UI.Library.Validations;
using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public class OrderEntryViewModel : INotifyPropertyChanged, IOrderEntryViewModel
    {

        #region Private Properties
        private CultureInfo cultureInfo = new CultureInfo("en-US");
        private string cin;
        private DateTime? sampleCollectionDate;
        private DateTime? sampleReceivedDate;
        private string nidPp;
        private string fullname;
        private string age;
        private string phoneNumber;
        private DateTime? birthdate;
        private string address;
        private string episodeNumber;
        private int selectedSiteId;
        private int selectedGenderId;
        private int selectedAtollId;
        private int selectedIslandId;
        private int selectedCountryId;
        private string testToAdd;
        private string cinErrorText;
        readonly OrderEntryValidator validator = new OrderEntryValidator();
        private readonly IMapper mapper;
        private StaticData staticData = new StaticData();
        private bool loadingStaticData;
        #endregion

        public event EventHandler<string> PushingLogs;
        public event EventHandler<string> PushingMessages;
        private event EventHandler InitializeStaticData;

        #region Default Constructor
        public OrderEntryViewModel(IMapper mapper)
        {
            Sites = new List<SitesModel>();
            Gender = new List<GenderModel>();
            Atolls = new List<AtollModel>();
            Islands = new BindingList<IslandModel>();
            Countries = new List<CountryModel>();
            AllTestsData = new List<ProfilesAndTestsDatasourceOeModel>();
            AddedTests = new BindingList<TestModel>();
            AllAtollsWithCorrespondingIsland = new List<AtollIslandModel>();
            ClinicalDetails = new BindingList<ClinicalDetailsOrderEntryModel>();

            //InitializeDemoData();
            this.mapper = mapper;
            PropertyChanged += OrderEntryViewModel_PropertyChanged;
            InitializeStaticData += OnInitializeStaticDataAsync;
            InitializeStaticData(this, EventArgs.Empty);
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
        public bool LoadingStaticDataStatus
        {
            get => loadingStaticData; set
            {
                loadingStaticData = value;
                OnPropertyChanged();
            }
        }
        private List<AtollIslandModel> AllAtollsWithCorrespondingIsland { get; set; }

        #region Request
        public string Cin
        {
            get => cin; set
            {
                if (cin == value) return;
                cin = value;
                OnPropertyChanged();
                ManageValidation();
            }
        }

        public string CinErrorText
        {
            get => cinErrorText; set
            {
                if (cinErrorText == value) return;
                cinErrorText = value;
                OnPropertyChanged();
            }
        }
        public List<SitesModel> Sites { get; set; }
        private SitesModel SelectedSite { get; set; }
        public int SelectedSiteId
        {
            get => selectedSiteId; set
            {
                if (selectedSiteId == value) return;
                selectedSiteId = value;
                SetSelectedSiteAsync(value).ConfigureAwait(true);
                //OnPropertyChanged(); called elsewhere
            }
        }
        public DateTime? SampleCollectionDate
        {
            get => sampleCollectionDate; set
            {
                // if (sampleCollectionDate == value) return;
                sampleCollectionDate = value;
                OnPropertyChanged();
            }
        }
        public DateTime? SampleReceivedDate
        {
            get => sampleReceivedDate; set
            {
                if (sampleReceivedDate == value) return;
                sampleReceivedDate = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Patient
        public string NidPp
        {
            get => nidPp; set
            {
                if (nidPp == value) return;
                nidPp = value;
                OnPropertyChanged();
            }
        }
        public string Fullname
        {
            get
            {
                return fullname;
            }

            set
            {
                if (fullname == value) return;
                fullname = value;
                OnPropertyChanged();
            }
        }
        public List<GenderModel> Gender { get; set; }
        public int SelectedGenderId
        {
            get => selectedGenderId; set
            {
                if (selectedGenderId == value) return;
                selectedGenderId = value;
                OnPropertyChanged();
            }
        }
        public string Age
        {
            get => age; set
            {
                if (age == value) return;
                age = value;
                OnPropertyChanged();
            }
        }
        public string PhoneNumber
        {
            get => phoneNumber; set
            {
                if (phoneNumber == value) return;
                phoneNumber = value;
                OnPropertyChanged();
            }
        }
        public DateTime? Birthdate
        {
            get => birthdate; set
            {
                if (birthdate == value) return;
                birthdate = value;
                SetAge((DateTime)value);
                OnPropertyChanged();
            }
        }
        public string Address
        {
            get => address; set
            {
                if (address == value) return;
                address = value;
                OnPropertyChanged();
            }
        }
        public List<AtollModel> Atolls { get; set; }
        public int SelectedAtollId
        {
            get => selectedAtollId; set
            {
                if (selectedAtollId == value) return;
                selectedAtollId = value;
                RepopulateIslandDatasource(value).ConfigureAwait(true);
                OnPropertyChanged();
            }
        }

        private async Task RepopulateIslandDatasource(int atollId)
        {
            var islandSearchResults = await SearchIslandsByAtoll
                                                (GetAtollById(atollId));

            //Clear the island list and add the new islands
            Islands.Clear();
            foreach (var results in islandSearchResults)
            {
                Islands.Add(new IslandModel()
                { Id = results.Id, Island = results.Island });
            }

        }

        private async Task<List<AtollIslandModel>> SearchIslandsByAtoll(string atollName)
        {
            if (atollName is null) throw new ArgumentNullException(nameof(atollName));
            return await Task.Run(() =>
            {
                return AllAtollsWithCorrespondingIsland.FindAll((i) =>
                {
                    return i.Atoll == atollName;
                });
            });
        }

        private string GetAtollById(int atollId)
        {
            if (atollId == 0) return string.Empty;
            return Atolls.SingleOrDefault((a) => a.Id == atollId).Atoll;
        }

        public BindingList<IslandModel> Islands { get; set; }
        public int SelectedIslandId
        {
            get => selectedIslandId; set
            {
                if (selectedIslandId == value) return;
                selectedIslandId = value;
                OnPropertyChanged();
            }
        }
        public List<CountryModel> Countries { get; set; }
        public int SelectedCountryId
        {
            get => selectedCountryId; set
            {
                if (selectedCountryId == value) return;
                selectedCountryId = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Clincal Details
        public BindingList<ClinicalDetailsOrderEntryModel> ClinicalDetails { get; set; }

        #endregion

        #region Selected Tests and Test Selection
        //Selected Tests
        public BindingList<TestModel> AddedTests { get; set; }

        //TestSelection
        public List<ProfilesAndTestsDatasourceOeModel> AllTestsData { get; set; }
        public string TestToAdd
        {
            get => testToAdd; set
            {
                if (testToAdd == value) return;
                testToAdd = value;
                OnPropertyChanged();
            }
        }
        public string EpisodeNumber
        {
            get => episodeNumber; set
            {
                if (episodeNumber == value) return;
                episodeNumber = value;
                OnPropertyChanged();
            }
        }

        #endregion

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

        public void RemoveTestModelFromAddedTests(TestModel testModel)
        {
            if (testModel is null) return;
            AddedTests.Remove(testModel);
        }

        public async Task OnReceiveSearchResults(PatientModel results)
        {
            Fullname = results.Fullname;
            NidPp = results.NidPp;
            Birthdate = results.Birthdate;
            PhoneNumber = results.PhoneNumber;
            Address = results.Address;

            await SetSelectedItemsForLookups(results);

        }

        private async Task SetSelectedItemsForLookups(PatientModel results)
        {
            if (results is null) return;
            var tasks = new List<Task<int>>
            {
                Task.Run(() => Gender.SingleOrDefault((g) => g.Gender == results.Gender).Id),
                Task.Run(() =>
                {
                    var atoll  = Atolls.SingleOrDefault((a) => a.Atoll == results.Atoll);
                    return atoll is null ? -1 : atoll.Id;
                }),

                Task.Run(() =>
                {
                    var country = Countries.SingleOrDefault((c) => c.Country == results.Country);
                    return country is null ? -1 : country.Id;
                })
            };

            var resultIds = await Task.WhenAll(tasks);

            //WARNING!: The assignment needs to be in the same order that the tasks were
            //added to the list of tasks. 
            SelectedGenderId = resultIds[0];
            if (!(resultIds[1] == -1)) { SelectedAtollId = resultIds[1]; }
            if (!(resultIds[2] == -1)) { SelectedCountryId = resultIds[2]; }

            //Set island based on selected atoll
            await RepopulateIslandDatasource(SelectedAtollId);
            var island = await Task.Run(() =>
            {
                var result = Islands.SingleOrDefault((i) => i.Island == results.Island);
                return result is null ? -1 : result.Id;
            });

            if (island > 0) { SelectedIslandId = island; }
        }

        #endregion

        #region Private Methods
        private void ManageValidation()
        {
            var results = ValidateOrderEntry();

            string errorMessages = null;
            if (!results.IsValid)
            {
                foreach (var message in results.Errors)
                {
                    errorMessages += message + "\n";
                }

                CinErrorText = errorMessages;
            }
            else
            {
                CinErrorText = null;
            }


        }

        private ValidationResult ValidateOrderEntry()
        {
            return validator.Validate(this);
        }

        private async Task AddTestListToRequestAsync
            (List<TestModel> testModelList)
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

        private async Task<ProfilesAndTestsDatasourceOeModel>
            GetSelectedTestOrProfileByDescriptionAsync(string testDescription)
        {
            return await Task.Run(() =>
            {
                return AllTestsData.SingleOrDefault(t => t.Description == testDescription);
            });
        }


        #region Load Static Data
        private async void OnInitializeStaticDataAsync(object sender, EventArgs e)
        {
            LoadingStaticDataStatus = true;

            try
            {
                await LoadAllCountriesAsync();
                await LoadAllSitesAsync();
                await LoadAllGenderAsync();
                await LoadAllAtollsAndIslandsAsync();
                await LoadAllClinicalDetailsAsync();
                await LoadAllTestsAsync();
                await LoadAllProfilesAsync();

            }
            catch (Exception ex)
            {
                PushingMessages?.Invoke(this, ex.Message);
            }
            finally
            {
                LoadingStaticDataStatus = false;
            }

            InitializeAtollsDatasource();
        }

        private async Task LoadAllProfilesAsync()
        {
            await Task.Run(async () =>
            {
                var results = await staticData.GetAllProfileTestsAsync();
                foreach (var item in results)
                {
                    this.AllTestsData.Add(mapper.Map<ProfilesAndTestsDatasourceOeModel>(item));
                }

            }).ConfigureAwait(true);


        }

        private async Task LoadAllTestsAsync()
        {
            var results = await staticData.GetAllTestsAsync();
            foreach (var item in results)
            {
                this.AllTestsData.Add(mapper.Map<ProfilesAndTestsDatasourceOeModel>(item));
            }
        }

        private async Task LoadAllClinicalDetailsAsync()
        {
            var results = await staticData.GetAllClinicalDetailsAsync();

            foreach (var item in results)
            {
                this.ClinicalDetails.Add(mapper.Map<ClinicalDetailsOrderEntryModel>(item));
            }

        }

        private async Task LoadAllAtollsAndIslandsAsync()
        {
            var results = await staticData.GetAllAtollsAndIslandsAsync();
            foreach (var item in results)
            {
                this.AllAtollsWithCorrespondingIsland.Add(mapper.Map<AtollIslandModel>(item));
            }
        }

        private async Task LoadAllGenderAsync()
        {

            var results = await staticData.GetAllGenderAsync();
            foreach (var item in results)
            {
                this.Gender.Add(mapper.Map<GenderModel>(item));
            }

        }

        private async Task LoadAllSitesAsync()
        {
            var results = await staticData.GetAllSitesAsync();
            foreach (var item in results)
            {
                this.Sites.Add(mapper.Map<SitesModel>(item));
            }
        }
        private async Task LoadAllCountriesAsync()
        {

            var results = await staticData.GetAllCountriesAsync();

            foreach (var item in results)
            {
                this.Countries.Add(mapper.Map<CountryModel>(item));
            }

        }

        #endregion
        private void InitializeDemoData()
        {
            //Sites
            var site1 = new SitesModel() { Id = 1, Site = "IGMH" };
            var site2 = new SitesModel() { Id = 2, Site = "FARUKOLHU" };

            this.Sites.Add(site1);
            this.Sites.Add(site2);

            //Gender
            var male = new GenderModel() { Id = 1, Gender = "MALE" };
            var female = new GenderModel() { Id = 2, Gender = "FEMALE" };
            var unknown = new GenderModel() { Id = 3, Gender = "UNKNOWN" };

            Gender.Add(male);
            Gender.Add(female);
            Gender.Add(unknown);

            //Atolls and Islands
            var ia1 = new AtollIslandModel()
            { Id = 1, Atoll = "Addu", Island = "Hithadhoo" };
            var ia2 = new AtollIslandModel()
            { Id = 2, Atoll = "Addu", Island = "Maradhoo" };
            var ia3 = new AtollIslandModel()
            { Id = 3, Atoll = "Male", Island = "Hulhumale" };
            var ia4 = new AtollIslandModel()
            { Id = 4, Atoll = "Male", Island = "Villingilli" };
            var ia5 = new AtollIslandModel()
            { Id = 5, Atoll = "Male", Island = "Male" };

            this.AllAtollsWithCorrespondingIsland.Add(ia1);
            this.AllAtollsWithCorrespondingIsland.Add(ia2);
            this.AllAtollsWithCorrespondingIsland.Add(ia3);
            this.AllAtollsWithCorrespondingIsland.Add(ia4);
            this.AllAtollsWithCorrespondingIsland.Add(ia5);


            //Country
            var c1 = new CountryModel() { Id = 1, Country = "Maldives" };
            var c2 = new CountryModel() { Id = 2, Country = "Pakistan" };

            Countries.Add(c1);
            Countries.Add(c2);

            //Clinical Details
            var cd1 = new ClinicalDetailsOrderEntryModel()
            { Id = 1, ClinicalDetail = "Fever", IsSelected = false };

            var cd2 = new ClinicalDetailsOrderEntryModel()
            { Id = 2, ClinicalDetail = "Cough", IsSelected = false };

            var cd3 = new ClinicalDetailsOrderEntryModel()
            { Id = 3, ClinicalDetail = "Runny nose", IsSelected = false };

            var cd4 = new ClinicalDetailsOrderEntryModel()
            { Id = 4, ClinicalDetail = "Shortness of Breath", IsSelected = false };

            var cd5 = new ClinicalDetailsOrderEntryModel()
            { Id = 5, ClinicalDetail = "Travel History", IsSelected = false };

            ClinicalDetails.Add(cd1);
            ClinicalDetails.Add(cd2);
            ClinicalDetails.Add(cd3);
            ClinicalDetails.Add(cd4);
            ClinicalDetails.Add(cd5);

            //Profiles and tests datasource
            var pt1 = new ProfilesAndTestsDatasourceOeModel()
            { Id = 1, Description = "Total Bilirubin", IsProfile = false, ResultDataType = "Numeric" };
            var pt2 = new ProfilesAndTestsDatasourceOeModel()
            { Id = 2, Description = "Direct Bilirubin", IsProfile = false, ResultDataType = "Numeric" };
            var pt3 = new ProfilesAndTestsDatasourceOeModel()
            { Id = 3, Description = "AST", IsProfile = false, ResultDataType = "Numeric" };

            var liver = new List<TestModel>()
            {
                pt1,
                pt2,
                pt3
            };

            var pt4 = new ProfilesAndTestsDatasourceOeModel()
            {
                Id = 4,
                Description = "Liver Profile",
                IsProfile = true,
                TestsInProfile = liver
            };

            AllTestsData.Add(pt1);
            AllTestsData.Add(pt2);
            AllTestsData.Add(pt3);
            AllTestsData.Add(pt4);


        }

        private void SetAge(DateTime birthdate)
        {
            Age = DateTimeExtensions.ToAgeString(birthdate);
        }

        private void InitializeAtollsDatasource()
        {
            var distinctAtoll = AllAtollsWithCorrespondingIsland
                .Select((a) => a.Atoll).Distinct();

            var counter = 1;
            foreach (var item in distinctAtoll)
            {
                Atolls.Add(new AtollModel() { Id = counter, Atoll = item });
                counter++;
            }
        }

        private void OrderEntryViewModel_PropertyChanged
            (object sender, PropertyChangedEventArgs e)
        {
            Debug.WriteLine("============= Property Change Handling START ============");
            Debug.WriteLine(e.PropertyName);
            //for debugging
            if (e.PropertyName == nameof(this.selectedSiteId))
            {
                Debug.WriteLine(JsonConvert.SerializeObject(SelectedSite, Formatting.Indented));
            }

            if(e.PropertyName == nameof(LoadingStaticDataStatus))
            {
                Debug.WriteLine($"LoadingDataStatus: {LoadingStaticDataStatus}");
            }

            Debug.WriteLine("============ Property Change Handling COMPLETE ==========");
        }

        private async Task SetSelectedSiteAsync(int siteId, [CallerMemberName] string propertyName = "")
        {
            Debug.WriteLine($"called {nameof(SetSelectedSiteAsync)}");
            var site = await GetSiteByIdAsync(siteId);
            if (site is null)
            {
                Debug.WriteLine($"Search Yeilded null");
                return;
            }
            SelectedSite = site;
            Debug.WriteLine($"Selected Site: {site.Id} | {site.Site}");
            Debug.WriteLine($"Completed call to {nameof(SetSelectedSiteAsync)}");
            OnPropertyChanged(propertyName);
        }

        private async Task<SitesModel> GetSiteByIdAsync(int siteId)
        {
            Debug.WriteLine($"Searching Site by Id. SiteID {siteId}");
            return await Task.Run(() =>
            {
                return Sites.SingleOrDefault(s => s.Id == siteId);
            });
        }
        #endregion
    }


}
