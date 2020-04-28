using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CD4.UI.Library.Model
{
    public class ScientistModel : INotifyPropertyChanged
    {
        private int id;
        private string scientist;

        public int Id
        {
            get => id; set
            {
                if (id == value) return;
                id = value;
                OnPropertyChanged();
            }
        }
        public string Scientist
        {
            get => scientist; set
            {
                if (scientist == value) return;
                scientist = value;
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