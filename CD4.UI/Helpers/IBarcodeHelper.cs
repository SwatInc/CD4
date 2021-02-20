using CD4.UI.Library.Model;
using System.Collections.Generic;

namespace CD4.UI.Helpers
{
    public interface IBarcodeHelper
    {
        bool PrintSingleSampleBarcode(List<BarcodeDataModel> barcodeData, string cin);
        bool PrintMultipleSampleBarcode(List<BarcodeDataModel> barcodeData);
    }
}