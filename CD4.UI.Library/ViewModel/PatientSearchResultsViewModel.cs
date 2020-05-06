using CD4.UI.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public class PatientSearchResultsViewModel : INotifyPropertyChanged, IPatientSearchResultsViewModel
    {
        public event EventHandler<PatientModel> PatientSelected;
        public List<PatientModel> SearchResults { get; set; }
        public string PatientNameForSearch { get; set; }
        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public async Task SearchByPatientNameAsync()
        {
            throw new NotImplementedException();
        }

    }
}
