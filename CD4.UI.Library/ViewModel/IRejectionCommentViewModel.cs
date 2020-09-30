using CD4.DataLibrary.Models;
using System.ComponentModel;

namespace CD4.UI.Library.ViewModel
{
    public interface IRejectionCommentViewModel
    {
        BindingList<CommentsSelectionModel> RejectionReasons { get; set; }
        CommentsSelectionModel SelectedReason { get; set; }
        bool IsLoading { get; set; }
        bool IsOkEnabled { get; set; }
        int ReasonsCountDisplayed { get; set; }
        bool IsReasonsListEnabled { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}