using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CD4.UI.Library.ViewModel;
using DevExpress.Utils.DirectXPaint;
using CD4.UI.Library.Model;
using CD4.UI.Library.Helpers;

namespace CD4.UI.View
{
    public partial class GenericCommentView : DevExpress.XtraEditors.XtraForm
    {
        private readonly IGenericCommentViewModel _viewModel;
        private readonly ICommentHelper _commentTypeHelper;

        [Browsable(false)] public new int? DialogResult { get; set; }
        public GenericCommentView(IGenericCommentViewModel viewModel, ICommentHelper commentTypeHelper, int resultId = -1 )
        {
            InitializeComponent();
            _viewModel = viewModel;
            _commentTypeHelper = commentTypeHelper;
            InitializeBinding();

            simpleButtonOk.Click += SimpleButtonOk_Click;
            listBoxControlRejectionReasons.Paint += VerifyDisplayedItemsCount;
            _viewModel.InitializeFetchReasonsAndComments(_commentTypeHelper, resultId);

            ManageCommentsPageVisibility();
        }

        private void ManageCommentsPageVisibility()
        {
            xtraTabPageComments.PageVisible = _viewModel.IsExistingSampleAndTestCommentsVisible;
        }

        private void VerifyDisplayedItemsCount(object sender, EventArgs e)
        {
            _viewModel.ReasonsCountDisplayed = listBoxControlRejectionReasons.ItemCount;
            _viewModel.SelectedReason = (CommentsSelectionModel)listBoxControlRejectionReasons.SelectedItem;
        }

        private void SimpleButtonOk_Click(object sender, EventArgs e)
        {
            DialogResult = _viewModel.SelectedReason.Id;
            _viewModel.Reasons.Clear();
            _viewModel.ExistingResultComments.Clear(); ;
            listBoxControlRejectionReasons.DataSource = null;
            gridControlExistingComments.DataSource = null;
            Close();
        }

        private void InitializeBinding()
        {
            listBoxControlRejectionReasons.DataSource = _viewModel.Reasons;
            listBoxControlRejectionReasons.DisplayMember = nameof(CommentsSelectionModel.Comment);
            listBoxControlRejectionReasons.ValueMember = nameof(CommentsSelectionModel.Id);
            listBoxControlRejectionReasons.DataBindings.Add(new Binding("Enabled", _viewModel, nameof(_viewModel.IsReasonsListEnabled)
                ,false, DataSourceUpdateMode.OnPropertyChanged));

            progressPanelLoadingReasons.DataBindings.Add(new Binding("Visible", _viewModel
                , nameof(_viewModel.IsLoading)));

            simpleButtonOk.DataBindings.Add(new Binding("Enabled", _viewModel, nameof(_viewModel.IsOkEnabled),
                false, DataSourceUpdateMode.OnPropertyChanged));

            //bind view title
            DataBindings.Add(new Binding("Text", _viewModel, nameof(_viewModel.ViewTitle)));

            //user instruction
            labelControlUserInstruction.DataBindings.Add(new Binding("Text", _viewModel, nameof(_viewModel.UserInstruction)));

            //existing comments
            gridControlExistingComments.DataSource = _viewModel.ExistingResultComments;

        }
    }
}