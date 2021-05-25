using CD4.UI.Library.Helpers;
using CD4.UI.Library.Model;
using System.ComponentModel;

namespace CD4.UI.Library.ViewModel
{
    public interface IGenericCommentViewModel
    {
        BindingList<CommentsSelectionModel> Reasons { get; set; }
        CommentsSelectionModel SelectedReason { get; set; }
        bool IsLoading { get; set; }
        bool IsOkEnabled { get; set; }
        int ReasonsCountDisplayed { get; set; }
        bool IsReasonsListEnabled { get; set; }
        string ViewTitle { get; set; }
        string UserInstruction { get; set; }
        bool IsExistingSampleAndTestCommentsVisible { get; set; }
        BindingList<ResultCommentModel> ExistingResultComments { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        void InitializeFetchReasonsAndComments(ICommentHelper commentHelper, int selectedResultId);
    }
}