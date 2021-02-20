using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CD4.ExcelInterface.Models
{
    public class MeasurementValues : INotifyPropertyChanged
    {
        private string testCode;
        private string measurementValue;
        private string unit;

        public string TestCode
        {
            get { return testCode; }
            set
            {
                testCode = value;
                OnPropertyChanged();
            }
        }
        public string MeasurementValue
        {
            get => measurementValue; set
            {
                measurementValue = value;
                OnPropertyChanged();
            }
        }
        public string Unit
        {
            get => unit; set
            {
                unit = value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged Lookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}