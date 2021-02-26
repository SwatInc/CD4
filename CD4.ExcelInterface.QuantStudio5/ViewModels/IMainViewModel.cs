using CD4.ExcelInterface.QuantStudio5.Models;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CD4.ExcelInterface.QuantStudio5.ViewModels
{
    public interface IMainViewModel
    {
        Config Configuration { get; set; }
        BindingList<InterfaceResults> InterfaceResults { get; set; }
        dynamic KitNames { get; }
        BindingList<LogModel> Logs { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        Task<bool> ExportToUploader();
        void InterpretData(int selectedKitId);
    }
}