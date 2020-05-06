using CD4.UI.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public interface IPatientSearchResultsViewModel
    {
        BindingList<PatientModel> SearchResults { get; set; }

        event EventHandler<PatientModel> PatientSelected;
        event PropertyChangedEventHandler PropertyChanged;

        string PatientNameForSearch { get; set; }
        Task SearchByPatientNameAsync();
        void UserSelectedPatient(PatientModel row);
    }
}