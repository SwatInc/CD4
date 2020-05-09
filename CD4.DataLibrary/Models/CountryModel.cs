using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CD4.DataLibrary.Models
{
    public class CountryModel : INotifyPropertyChanged
    {
        private int id;
        private string country;

        public int Id
        {
            get => id; set
            {
                if (id == value) return;
                id = value;
                OnPropertyChanged();
            }
        }
        public string Country
        {
            get => country; set
            {
                if (country == value) return;
                country = value;
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