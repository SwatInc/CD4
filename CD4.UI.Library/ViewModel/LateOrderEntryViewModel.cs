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

namespace CD4.UI.Library.ViewModel
{
    public class LateOrderEntryViewModel : ILateOrderEntryViewModel, INotifyPropertyChanged
    {
        #region Private fields & Private Properties
        private string _testToAdd;
        private bool _loadingStaticData;
        private readonly IMapper _mapper;
        private readonly IStaticDataDataAccess _staticData;
        private readonly AuthorizeDetailEventArgs _authorizeDetail;
        private readonly IResultDataAccess _resultDataAccess;
        private  List<TestModel> _testsAlreadyPresentOnSample;
        private string _cin = string.Empty;
        #endregion

        public event EventHandler<string> PushingLogs;
        public event EventHandler<string> PushingMessages;
        private event EventHandler InitializeStaticData;

        #region Default Constructor
        public LateOrderEntryViewModel(IMapper mapper,
            IStaticDataDataAccess staticData,
            AuthorizeDetailEventArgs authorizeDetail,
            IResultDataAccess resultDataAccess)
        {
            AddedTests = new BindingList<TestModel>();
            AllTestsData = new List<ProfilesAndTestsDatasourceOeModel>();
            _testsAlreadyPresentOnSample = new List<TestModel>();

            _mapper = mapper;
            _staticData = staticData;
            _authorizeDetail = authorizeDetail;
            _resultDataAccess = resultDataAccess;

            InitializeStaticData += OnInitializeStaticDataAsync;
            InitializeStaticData(this, EventArgs.Empty);

        }

        #endregion

        #region Public Properties
        public List<ProfilesAndTestsDatasourceOeModel> AllTestsData { get; set; }
        public BindingList<TestModel> AddedTests { get; set; }
        public string TestToAdd
        {
            get => _testToAdd; set
            {
                if (_testToAdd == value) return;
                _testToAdd = value;
                OnPropertyChanged();
            }
        }

        public bool LoadingStaticDataStatus
        {
            get => _loadingStaticData; set
            {
                _loadingStaticData = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Public Methods
        public async Task<bool> ConfirmAnalysisRequestAync()
        {
            var testsToInsert = _mapper.Map<List<DataLibrary.Models.TestsModel>>(AddedTests);
            try
            {
                await _resultDataAccess.ManageReflexTests(testsToInsert,_cin, _authorizeDetail.UserId);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

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

        public void SetCurrentTestsOnSample(List<ResultModel> sampleResultData)
        {
            if (sampleResultData != null)
            {
                _testsAlreadyPresentOnSample = 
                    _mapper.Map<List<TestModel>>(sampleResultData);

                _cin = sampleResultData.FirstOrDefault().Cin;
            }

        }

        #endregion

        #region Private Methods

        private async void OnInitializeStaticDataAsync(object sender, EventArgs e)
        {
            LoadingStaticDataStatus = true;

            try
            {
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
        }

        private async Task LoadAllProfilesAsync()
        {
            await Task.Run(async () =>
            {
                var results = await _staticData.GetAllProfileTestsAsync();
                foreach (var item in results)
                {
                    AllTestsData.Add(_mapper.Map<ProfilesAndTestsDatasourceOeModel>(item));
                }

            }).ConfigureAwait(true);


        }

        private async Task LoadAllTestsAsync()
        {
            var results = await _staticData.GetAllTestsAsync();
            foreach (var item in results)
            {
                AllTestsData.Add(_mapper.Map<ProfilesAndTestsDatasourceOeModel>(item));
            }
        }

        private async Task<ProfilesAndTestsDatasourceOeModel>
            GetSelectedTestOrProfileByDescriptionAsync(string testDescription)
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
            Debug.WriteLine("Checking whether the test is already added or is already present on sample");
            return await Task.Run(() =>
            {
                var isTestAdded =  AddedTests.Any((t) => t.Description == testDescription);
                var isPresentOnSample = _testsAlreadyPresentOnSample.Any((t) => t.Description == testDescription);
                return isTestAdded || isPresentOnSample;
            });
        }
        #endregion

        #region INotifyPropertyChanged Lookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
