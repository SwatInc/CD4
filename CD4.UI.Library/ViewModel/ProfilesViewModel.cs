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
    public class ProfilesViewModel : INotifyPropertyChanged, IProfilesViewModel
    {
        #region Private Properties
        private bool dataAddControlsEnabled;
        private bool otherFunctionButtons;
        private string newProfileName;
        #endregion

        #region Events
        public event EventHandler<string> PushingLogs;
        public event EventHandler<string> PushingMessages;
        #endregion

        #region Default Constructor
        public ProfilesViewModel()
        {
            this.ProfileList = new BindingList<ProfileConfigModel>();
            this.Tests = new BindingList<ProfileConfigTestModel>();
            this.ProfileTestsForSelectedProfile = new BindingList<ProfileConfigProfileTestsModel>();
            this.AllProfileTests = new BindingList<ProfileConfigProfileTestsModel>();
            this.SelectedProfileTest = new ProfileConfigProfileTestsModel();

            InitializeDemoData();
            InitializeUiState(UiState.Adding);
            InitializeUiState(UiState.Default);

        }

        #endregion

        #region Private Methods
        private void InitializeUiState(UiState uiState)
        {
            switch (uiState)
            {
                case UiState.Adding:
                    DataAddControlsEnabled = true;
                    break;
                case UiState.Default:
                    DataAddControlsEnabled = false;
                    break;
                case UiState.BusyOperation:
                    DataAddControlsEnabled = false;
                    OtherFunctionButtons = false;
                    break;
                default:
                    break;
            }
        }

        private void InitializeDemoData()
        {
            //All tests
            var t1 = new ProfileConfigTestModel() { Id = 213, TestDescription = "TBIL" };
            var t2 = new ProfileConfigTestModel() { Id = 563, TestDescription = "DBIL" };

            //Profiles
            var p1 = new ProfileConfigModel() { Id = 1, Profile = "Liver Profile", State = State.Clean };
            var p2 = new ProfileConfigModel() { Id = 2, Profile = "Lipid Profile", State = State.Clean };

            //Profile Tests
            var pt1 = new ProfileConfigProfileTestsModel()
            { Id = 1, ProfileDescription = "Liver Profile", TestDescription = "TBIL", State = State.Clean };

            var pt2 = new ProfileConfigProfileTestsModel()
            { Id = 2, ProfileDescription = "Liver Profile", TestDescription = "DBIL", State = State.Clean };

            //Add All Tests
            this.Tests.Add(t1);
            this.Tests.Add(t2);

            //Add profiles
            ProfileList.Add(p1);
            ProfileList.Add(p2);

            //Add profile tests to all profile tests model.
            AllProfileTests.Add(pt1);
            AllProfileTests.Add(pt2);
        }

        private IEnumerable<ProfileConfigProfileTestsModel> FilterProfileTestsByTest
            (ProfileConfigModel filter)
        {
            if (filter is null) throw new ArgumentNullException
                    ("The filter passed in is null.");

            return from profileTests in AllProfileTests
                   where profileTests.ProfileDescription == filter.Profile
                   select profileTests;

        }


        #endregion

        #region Public Properties / Fields
        public BindingList<ProfileConfigModel> ProfileList { get; set; }
        public BindingList<ProfileConfigTestModel> Tests { get; set; }
        public ProfileConfigModel SelectedProfile { get; set; }
        public ProfileConfigTestModel SelectedTest { get; set; }
        public BindingList<ProfileConfigProfileTestsModel> AllProfileTests { get; set; } //A collection of all the tests belonging to all profiles.
        public BindingList<ProfileConfigProfileTestsModel> ProfileTestsForSelectedProfile { get; set; } //A collection of all tests belonging to the currently selected profile.
        public ProfileConfigProfileTestsModel SelectedProfileTest { get; set; } //A single test selected amoung current profile tests.

        public bool DataAddControlsEnabled
        {
            get => dataAddControlsEnabled; private set
            {
                if (dataAddControlsEnabled == value) 
                {
                    OtherFunctionButtons = !DataAddControlsEnabled;
                    return; 
                }
                dataAddControlsEnabled = value;
                OnPropertyChanged();

                OtherFunctionButtons = !DataAddControlsEnabled;
            }
        }
        public bool OtherFunctionButtons
        {
            get => otherFunctionButtons; private set
            {
                if (otherFunctionButtons == value) return;
                otherFunctionButtons = value;
                OnPropertyChanged();
            }
        }
        public string NewProfileName
        {
            get => newProfileName; set
            {
                if (newProfileName == value) return;
                newProfileName = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Public Methods
        public void UiPrepForAddingProfile(object sender, EventArgs e)
        {
            InitializeUiState(UiState.Adding);
        }

        public void SaveProfile(object sender, EventArgs e)
        {
            InitializeUiState(UiState.Default);

            if (string.IsNullOrEmpty(newProfileName)) return;

            this.ProfileList.Add(new ProfileConfigModel()
            {
                Id = -1,
                Profile = newProfileName,
                State = State.Added
            });

            NewProfileName = null;
        }

        public async Task  SelectedProfileChanged(ProfileConfigModel selectedProfile)
        {
            InitializeUiState(UiState.BusyOperation);
            //return if parameter is null
            if (selectedProfile is null) 
            {
                InitializeUiState(UiState.Default);
                return; 
            }

            //Clear the current profile tests
            this.ProfileTestsForSelectedProfile.Clear();

            //Find the profile tests corresponding to the selected profile
            var displayProfileTests = await Task.Run(() =>
            {
                return FilterProfileTestsByTest(selectedProfile);
            });

            //Iterate and add the tests to the current profile tests.
            foreach (var profileTest in displayProfileTests)
            {
                ProfileTestsForSelectedProfile.Add(profileTest);
            }

            InitializeUiState(UiState.Default);
        }

        public void AddItemToProfile(ProfileConfigModel profile,
            ProfileConfigTestModel test, ProfileConfigProfileTestsModel profileTest)
        {
            if (profile is null || test is null) return;
            Debug.WriteLine($"\nSELECTED PROFILE: {profile.Profile}\n");
            Debug.WriteLine($"\nSELECTED TEST: {test.TestDescription}\n");
            //If test is already included in the profile, ignore, return.
            Debug.WriteLine("\nPHASE 2: DETERMINE WHETHER THE TEST IS ALREADY INCLUDED IN THE PROFILE.\n");

            var a = from profileTests in AllProfileTests
                              where profileTests.TestDescription == test.TestDescription
                              && profileTests.ProfileDescription == profile.Profile
                              select profileTests;

            if (a is null || a.Count() == 0)
            {
                Debug.WriteLine("\nTest not present in profile\n");
                
            }
            else
            {
                foreach (var item in a)
                {
                    Debug.WriteLine("Search Match: " + item.TestDescription);
                }
            }

            Debug.WriteLine("======================================================================");
        }

        #endregion

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


    }

}
