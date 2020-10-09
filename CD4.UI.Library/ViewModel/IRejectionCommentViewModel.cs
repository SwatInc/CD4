using CD4.UI.Library.Model;
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
        RejectionReasonType ReasonType { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}