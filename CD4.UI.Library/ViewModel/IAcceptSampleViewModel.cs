using System.ComponentModel;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public interface IAcceptSampleViewModel
    {
        string AcceptBarcode { get; set; }
        bool IsProcessing { get; set; }
        string NoOfBarcodeReadDisplay { get; set; }
        string SuccessfullMessage { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        Task AcceptBarcodeAsync();
    }
}