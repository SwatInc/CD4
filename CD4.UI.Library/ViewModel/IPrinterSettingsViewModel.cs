using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public interface IPrinterSettingsViewModel
    {
        List<string> LocalPrintersList { get; set; }
        List<string> PrinterTypes { get; set; }
        string SelectedPrinterType { get; set; }
        string SelectedPriter { get; set; }
        BindingList<string> WorkStationPrinters { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        Task<List<string>> GetPrinterTypesAsync();
        Task<BindingList<string>> GetWorkStationPrintersAsync();
    }
}