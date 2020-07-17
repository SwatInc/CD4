using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public class PrinterSettingsViewModel : INotifyPropertyChanged, IPrinterSettingsViewModel
    {
        public PrinterSettingsViewModel()
        {
            //Initialize lists
            LocalPrintersList = new List<string>();
            PrinterTypes = new List<string>();
            WorkStationPrinters = new BindingList<string>();

            //Get data
            PrinterTypes = GetPrinterTypesAsync().GetAwaiter().GetResult();
            WorkStationPrinters = GetWorkStationPrintersAsync().GetAwaiter().GetResult();
            LocalPrintersList = DetectLocalPrinters();
        }

        public List<string> LocalPrintersList { get; set; }
        public string SelectedPriter { get; set; }
        public List<string> PrinterTypes { get; set; }
        public string SelectedPrinterType { get; set; }
        public BindingList<string> WorkStationPrinters { get; set; }

        //Get printer types for workstation from database
        public async Task<List<string>> GetPrinterTypesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<BindingList<string>> GetWorkStationPrintersAsync()
        {
            throw new NotImplementedException();
        }

        //detect local printers
        private List<string> DetectLocalPrinters()
        {
            throw new NotImplementedException();
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
