using CD4.UI.Library.Model;
using System;
using System.ComponentModel;

namespace CD4.UI.Library.ViewModel
{
    public interface IClinicalDetailsViewModel
    {
        BindingList<ClinicalDetailsModel> ClinicalDetailsList { get; set; }
        ClinicalDetailsModel SelectedRow { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
        event EventHandler<string> PushingLogs;
        event EventHandler<string> PushingMessages;

        void DisplaySelectedClinicalDetailsData(int selectedId);
        void SaveCountry(object sender, EventArgs e);
    }
}