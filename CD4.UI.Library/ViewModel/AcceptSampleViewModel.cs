using CD4.DataLibrary.DataAccess;
using CD4.UI.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CD4.UI.Library.ViewModel
{
    public class AcceptSampleViewModel : INotifyPropertyChanged, IAcceptSampleViewModel
    {
        private string _acceptBarcode;
        private string _successfullMessage;
        private string _noOfBarcodeReadDisplay;
        private bool _isProcessing;
        private int _noOfBarcodesRead;
        private readonly string NoReadTemplate = "No. Accepted";
        private readonly string SuccessfullMessageTemplate = "Successfully accepted barcode";
        private readonly IStatusDataAccess _statusDataAccess;
        private readonly AuthorizeDetailEventArgs _authorizeDetail;

        public AcceptSampleViewModel(IStatusDataAccess statusDataAccess, AuthorizeDetailEventArgs authorizeDetail)
        {
            SuccessfullMessage = string.Empty;
            NoOfBarcodesRead = 0;
            IsProcessing = false;
            _statusDataAccess = statusDataAccess;
            _authorizeDetail = authorizeDetail;
        }

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private int NoOfBarcodesRead
        {
            get => _noOfBarcodesRead; set
            {
                _noOfBarcodesRead = value;
                NoOfBarcodeReadDisplay = $"{NoReadTemplate}: {value}";
            }
        }
        public string AcceptBarcode
        {
            get => _acceptBarcode; set
            {
                _acceptBarcode = value;
                OnPropertyChanged();
            }
        }
        public string SuccessfullMessage
        {
            get => _successfullMessage; set
            {
                _successfullMessage = value;
                OnPropertyChanged();
            }
        }
        public string NoOfBarcodeReadDisplay
        {
            get => _noOfBarcodeReadDisplay; set
            {
                _noOfBarcodeReadDisplay = value;
                OnPropertyChanged();
            }
        }
        public bool IsProcessing
        {
            get => _isProcessing; set
            {
                _isProcessing = value;
                OnPropertyChanged();
            }
        }
        public async Task AcceptBarcodeAsync()
        {
            IsProcessing = true;
            try
            {
                NoOfBarcodesRead += 1;
                var response = await _statusDataAccess.MarkCollectedSampleAsAccepted(AcceptBarcode, _authorizeDetail.UserId);
                if (response.SampleData.Cin == AcceptBarcode && response.SampleData.StatusId == 3)
                {
                    SuccessfullMessage = $"{SuccessfullMessageTemplate}: {AcceptBarcode}";
                    AcceptBarcode = string.Empty;
                }

                IsProcessing = false;

            }
            catch (Exception)
            {
                IsProcessing = false;
                throw;
            }
        }

    }
}
