using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CD4.UI.Library.Model
{
    public class ClinicalDetailsModel : INotifyPropertyChanged
    {
        private int id;
        private string clinicalDetail;

        public int Id
        {
            get => id; set
            {
                if (Id == value) return;
                id = value;
                OnPropertyChanged();
            }
        }
        public string ClinicalDetail
        {
            get => clinicalDetail; set
            {
                if (clinicalDetail == value) return;
                clinicalDetail = value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}