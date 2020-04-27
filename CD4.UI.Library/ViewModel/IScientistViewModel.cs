using CD4.UI.Library.Model;
using System;
using System.ComponentModel;

namespace CD4.UI.Library.ViewModel
{
    public interface IScientistViewModel
    {
        BindingList<ScientistModel> ScientistList { get; set; }
        ScientistModel SelectedRow { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
        event EventHandler<string> PushingLogs;
        event EventHandler<string> PushingMessages;

        void DisplaySelectedData(int selectedId);
        void SaveScientist(object sender, EventArgs e);
    }
}