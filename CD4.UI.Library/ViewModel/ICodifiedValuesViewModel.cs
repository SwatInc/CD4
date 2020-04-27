using CD4.UI.Library.Model;
using System.ComponentModel;

namespace CD4.UI.Library.ViewModel
{
    public interface ICodifiedResultsViewModel
    {
        BindingList<CodifiedValueModel> CodifiedValuesList { get; set; }
        CodifiedValueModel SelectedRow { get; set; }
    }
}