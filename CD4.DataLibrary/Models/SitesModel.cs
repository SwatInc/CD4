using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CD4.DataLibrary.Models
{
    public class SitesModel : INotifyPropertyChanged
    {
        private int id;
        private string site;

        public int Id
        {
            get => id; set
            {
                if (id == value) return;
                id = value;
                OnPropertyChanged();
            }
        }
        public string Site
        {
            get => site; set
            {
                if (site == value) return;
                site = value;
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