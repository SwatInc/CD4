using CD4.UI.Library.Model;
using System;
using System.ComponentModel;

namespace CD4.UI.Library.ViewModel
{
    public interface IGenderViewModel
    {
        BindingList<GenderModel> GenderList { get; set; }
        GenderModel SelectedRow { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
        event EventHandler<string> PushingLogs;
        event EventHandler<string> PushingMessages;

        void DisplaySelectedData(int selectedId);
        void SaveGender(object sender, EventArgs e);
    }
}