using System;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CD4.UI.Library.Model
{
    public class ResultModel : INotifyPropertyChanged
    {
        public ResultModel()
        {
        }
        #region Private Properties

        private int id;
        private int analysisRequestId;
        private string cin;
        private string test;
        private string result;
        private DateTime resultDate;
        private string dataType;
        private string mask;
        private int statusIconName;
        private string unit;
        private string _referenceCode;
        private bool _isDeltaOk;

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
        public Image StatusIcon { get; private set; }
        public int StatusIconId
        {
            get => statusIconName; set
            {
                statusIconName = value;
                SetIcon(value);
            }
        }

        private void SetIcon(int statusIconId)
        {
            switch (statusIconId)
            {
                case 1:
                    StatusIcon = Properties.Resources.Requested;
                    break;
                case 2:
                    StatusIcon = Properties.Resources.Sampled;
                    break;
                case 3:
                    StatusIcon = Properties.Resources.Received;
                    break;
                case 4:
                    StatusIcon = Properties.Resources.ToValidate;
                    break;
                case 5:
                    StatusIcon = Properties.Resources.Validated;
                    break;
                case 6:
                    StatusIcon = Properties.Resources.Processing;
                    break;
                case 7:
                    StatusIcon = Properties.Resources.Rejected;
                    break;
                default:
                    break;
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
        public string Mask
        {
            get => mask; set
            {
                if (mask == value) return;
                mask = value;
                OnPropertyChanged();
            }
        }

        public string Unit
        {
            get => unit; set
            {
                if (unit == value)
                {
                    return;
                }
                unit = value;
                OnPropertyChanged();
            }
        }

        public string ReferenceCode
        {
            get => _referenceCode; set
            {
                if (_referenceCode == value) return;
                _referenceCode = value;
                OnPropertyChanged();
            }
        }

        public bool IsDeltaOk
        {
            get => _isDeltaOk; set
            {
                if (_isDeltaOk == value) return;
                _isDeltaOk = value;
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
