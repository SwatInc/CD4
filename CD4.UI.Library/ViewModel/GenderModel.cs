using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CD4.UI.Library.Model
{
    public class GenderModel : INotifyPropertyChanged
    {
        private int id;
        private string gender;

        public int Id
        {
            get => id; set
            {
                if (id == value) return;
                id = value;
                OnPropertyChanged();
            }
        }
        public string Gender
        {
            get => gender; set
            {
                if (gender == value) return;
                gender = value;
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