using CD4.UI.Library.Model;
using System;
using System.ComponentModel;

namespace CD4.UI.Library.ViewModel
{
    public interface ICodifiedResultsViewModel
    {
        BindingList<CodifiedResultsModel> CodifiedValuesList { get; set; }
        CodifiedResultsModel SelectedRow { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
        event EventHandler<string> PushingLogs;
        event EventHandler<string> PushingMessages;

        void DisplaySelectedCodifiedData(int selectedId);
        void SavePhrase(object sender, EventArgs e);
    }
}