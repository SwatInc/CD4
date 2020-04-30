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
            var p1 = new ProfileConfigModel() { Id = 1, ProfileDescription = "Liver Profile", State = State.Clean };
            var p2 = new ProfileConfigModel() { Id = 2, ProfileDescription = "Lipid Profile", State = State.Clean };

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

        /// <summary>
        /// Searches all profile tests to look for a profile tests matching 
        /// the ProfileConfigModel provided.
        /// </summary>
        /// <param name="filter"> The criteria to look for a match</param>
        /// <returns></returns>
        private IEnumerable<ProfileConfigProfileTestsModel> FilterProfileTestsByTest
            (ProfileConfigModel filter)
        {
            if (filter is null) throw new ArgumentNullException
                    ("The filter passed in is null.");

            return from profileTests in AllProfileTests
                   where profileTests.ProfileDescription == filter.ProfileDescription
                   select profileTests;

        }

        /// <summary>
        /// Search all profile tests looking for matches with the provided selected
        /// profile and provided selected test.
        /// </summary>
        /// <param name="profile">the profile to look for</param>
        /// <param name="tests">the tests to look for</param>
        /// <returns>An IEnumerable of profile tests matching both the criteria</returns>
        private IEnumerable<ProfileConfigProfileTestsModel> FilterProfileTestsByProfileAndTestDesc
            (ProfileConfigModel profile, ProfileConfigTestModel tests)
        {
            return from profileTests in AllProfileTests
                   where profileTests.TestDescription == tests.TestDescription
                   && profileTests.ProfileDescription == profile.ProfileDescription
                   select profileTests;

        }

        private void AddTestToProfile(string profileDescription, string testDescription)
        {
            AllProfileTests.Add(new ProfileConfigProfileTestsModel()
            {
                Id=-1,
                ProfileDescription=profileDescription,
                TestDescription = testDescription,
                State=State.Added
            });
        }

        private void RemoveAllProfileTestsInProfile(string profileName)
        {
            var allSpecifiedProfileTests = from profileTest in AllProfileTests
                                           where profileTest.ProfileDescription == profileName
                                           select profileTest;

            if (allSpecifiedProfileTests is null) return;
            var allSpecifiedProfileTestsList = allSpecifiedProfileTests.ToList();
            var DeleteProfilesCount = allSpecifiedProfileTestsList.Count();
            if (DeleteProfilesCount == 0) return;

            for (int i = 0; i < DeleteProfilesCount; i++)
            {
                AllProfileTests.Remove(allSpecifiedProfileTestsList.ElementAt(i));
            }
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
                ProfileDescription = newProfileName,
                State = State.Added
            });

            NewProfileName = null;
        }

        public async Task SelectedProfileChanged(ProfileConfigModel selectedProfile)
        {
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

        }

        public async Task ManageAddItemToProfile(ProfileConfigModel profile,
            ProfileConfigTestModel test)
        {
            if (profile is null || test is null) return;

            var ProfileTests_MatchingSelectedProfileAndSelectedTest = await Task.Run(() =>
               {
                   return FilterProfileTestsByProfileAndTestDesc(profile, test);
               });

            //decide to add and add the test to profile.
            if (ProfileTests_MatchingSelectedProfileAndSelectedTest is null 
                || ProfileTests_MatchingSelectedProfileAndSelectedTest.Count() == 0)
            {
                AddTestToProfile(profile.ProfileDescription, test.TestDescription);
            }

            //Refresh the UI to reflect the changes.
            await SelectedProfileChanged(profile);
        }

        public async Task RemoveProfileTestFromProfile
            (ProfileConfigProfileTestsModel testToRemove)
        {
            //Remove the test from all profile tests
            this.AllProfileTests.Remove(testToRemove);
            //Refresh the selected profile tests
            await SelectedProfileChanged(SelectedProfile);
        }

        public async Task DeleteProfile(ProfileConfigModel profile)
        {
            await Task.Run(() =>
            {
                RemoveAllProfileTestsInProfile(profile.ProfileDescription);
            });

            ProfileList.Remove(profile);
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
