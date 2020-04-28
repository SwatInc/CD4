using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CD4.UI.Library.ViewModel
{
    public class TestModel : INotifyPropertyChanged
    {
        private string mask;
        private int id;
        private string description;
        private string resultDataType;
        private bool isReportable;

        public int Id
        {
            get => id; set
            {
                if (id == value) return;
                id = value;
                OnPropertyChanged();
            }
        }
        public string Description
        {
            get => description; set
            {
                if (description == value) return;
                description = value;
                OnPropertyChanged();
            }
        }
        public string ResultDataType
        {
            get => resultDataType; set
            {
                if (resultDataType == value) return;
                resultDataType = value;
                OnPropertyChanged();
            }
        }
        public string Mask
        {
            get => mask; set
            {
                if (mask == value) return;
                mask = value;
                OnPropertyChanged();
            }
        }
        public bool IsReportable
        {
            get => isReportable; set
            {
                if (isReportable == value) return;
                isReportable = value;
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