using CD4.UI.Library.Model;
using System;
using System.ComponentModel;

namespace CD4.UI.Library.ViewModel
{
    public interface ICodifiedResultsViewModel
    {
        BindingList<CodifiedResultsModel> CodifiedValuesList { get; set; }
        bool IsButtonEditEnabled { get; set; }
        bool IsButtonSaveEnabled { get; set; }
        bool IsTextEditCodifiedResultEnabled { get; set; }
        bool IsTextEditIdEnabled { get; set; }
        CodifiedResultsModel PreviousRow { get; set; }
        CodifiedResultsModel SelectedRow { get; set; }
        State UserInputState { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
        event EventHandler<string> PushingLogs;

        void ChangeDisplayedCodifiedData(int selectedId);
    }
}