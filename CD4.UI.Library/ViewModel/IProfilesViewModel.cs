using CD4.UI.Library.Model;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public interface IProfilesViewModel
    {        
        #region Events

        event PropertyChangedEventHandler PropertyChanged;
        event EventHandler<string> PushingLogs;
        event EventHandler<string> PushingMessages;

        #endregion

        #region Profile Related
        BindingList<ProfileConfigModel> ProfileList { get; set; }
        ProfileConfigModel SelectedProfile { get; set; }

        #endregion

        #region All Tests Related
        BindingList<ProfileConfigTestModel> Tests { get; set; }
        ProfileConfigTestModel SelectedTest { get; set; }

        #endregion

        #region Profile Test(s) Models / Lists
        BindingList<ProfileConfigProfileTestsModel> AllProfileTests { get; set; } //A collection of all the tests belonging to all profiles.
        BindingList<ProfileConfigProfileTestsModel> ProfileTestsForSelectedProfile { get; set; } //A collection of all tests belonging to the currently selected profile.
        ProfileConfigProfileTestsModel SelectedProfileTest { get; set; } //A single test selected amoung current profile tests.

        #endregion

        #region Behaviour Related
        bool DataAddControlsEnabled { get; }
        bool OtherFunctionButtons { get; }
        string NewProfileName { get; set; }
        void UiPrepForAddingProfile(object sender, EventArgs e);
        void SaveProfile(object sender, EventArgs e);
        Task SelectedProfileChanged(ProfileConfigModel selectedProfile);
        Task ManageAddItemToProfile(ProfileConfigModel profile, ProfileConfigTestModel test);
        Task RemoveProfileTestFromProfile(ProfileConfigProfileTestsModel testToRemove);
        Task DeleteProfile(ProfileConfigModel profile);
        #endregion

    }
}