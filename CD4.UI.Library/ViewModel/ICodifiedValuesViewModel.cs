using CD4.UI.Library.Model;
using System.ComponentModel;

namespace CD4.UI.Library.ViewModel
{
    public interface ICodifiedResultsViewModel
    {
        BindingList<CodifiedResultsModel> CodifiedValuesList { get; set; }
        CodifiedResultsModel SelectedRow { get; set; }

        void ChangeDisplayedCodifiedData(int selectedId);
    }
}