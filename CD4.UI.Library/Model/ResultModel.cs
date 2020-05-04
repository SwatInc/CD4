using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CD4.UI.Library.Model
{
    public class ResultModel : INotifyPropertyChanged
    {
        #region Private Properties
        private int id;
        private int analysisRequestId;
        private string cin;
        private string test;
        private string result;
        private DateTime resultDate;
        private string dataType;

        #endregion

        #region Public Properties
        public int Id
        {
            get => id; set
            {
                if (id == value) return;
                id = value;
                OnPropertyChanged();
            }
        }
        public int AnalysisRequestId
        {
            get => analysisRequestId; set
            {
                if (analysisRequestId == value) return;
                analysisRequestId = value;
                OnPropertyChanged();
            }
        }
        public string Cin
        {
            get => cin; set
            {
                if (cin == value) return;
                cin = value;
                OnPropertyChanged();
            }
        }
        public string Test
        {
            get => test; set
            {
                if (test == value) return;
                test = value;
                OnPropertyChanged();
            }
        }
        public string Result
        {
            get => result; set
            {
                if (result == value) return;
                result = value;
                OnPropertyChanged();
            }
        }
        public DateTime ResultDate
        {
            get => resultDate; set
            {
                if (resultDate == value) return;
                resultDate = value;
                OnPropertyChanged();
            }
        }
        public string DataType
        {
            get => dataType; set
            {
                if (dataType == value) return;
                dataType = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
