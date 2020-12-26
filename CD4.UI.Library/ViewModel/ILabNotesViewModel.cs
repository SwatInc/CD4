using CD4.UI.Library.Model;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public interface ILabNotesViewModel
    {
        BindingList<SampleNotesModel> Notes { get; set; }
        string ViewName { get; set; }
        string NewNote { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        void AddNewNote();
    }
}