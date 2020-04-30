using CD4.UI.Library.Model;
using System;
using System.ComponentModel;

namespace CD4.UI.Library.ViewModel
{
    public interface IProfilesViewModel
    {
        BindingList<ProfileConfigModel> ProfileList { get; set; }
        BindingList<ProfileConfigTestModel> Tests { get; set; }
        ProfileConfigModel SelectedProfile { get; set; }
        ProfileConfigTestModel SelectedTest { get; set; }
        bool DataAddControlsEnabled { get; }
        bool OtherFunctionButtons { get; }
        string NewProfileName { get; set; }
        void UiPrepForAddingProfile(object sender, EventArgs e);
        void SaveProfile(object sender, EventArgs e);

        event PropertyChangedEventHandler PropertyChanged;
        event EventHandler<string> PushingLogs;
        event EventHandler<string> PushingMessages;
    }
}