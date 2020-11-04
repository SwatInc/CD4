using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CD4.UI.Library.ViewModel;
using CD4.UI.Library.Model;

namespace CD4.UI.View
{
    public partial class ChangePasswordView : XtraForm
    {
        private readonly IChangePasswordViewModel viewModel;
        private readonly AuthorizeDetailEventArgs _authorizeDetail;

        public ChangePasswordView(IChangePasswordViewModel viewModel, AuthorizeDetailEventArgs authorizeDetail)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            _authorizeDetail = authorizeDetail;
            InitializeBinding();

            //set viewMOdel username
            viewModel.LoggedInUserName = _authorizeDetail.Username;

            //subscribe for events
            simpleButtonChangePassword.Click += ChangePassword;
            viewModel.PrompToView += ViewModel_PrompToView;
        }

        private void ViewModel_PrompToView(object sender, string e)
        {
            XtraMessageBox.Show(e);
        }

        private async void ChangePassword(object sender, EventArgs e)
        {
            try
            {
                await viewModel.ChangePassword();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void InitializeBinding()
        {
            //current password
            textEditCurrentPassword.DataBindings.Add
                (new Binding("EditValue", viewModel, nameof(viewModel.CurrentPassword), false, DataSourceUpdateMode.OnPropertyChanged));
            //new password
            textEditNewPassword.DataBindings.Add
                (new Binding("EditValue", viewModel, nameof(viewModel.NewPassword), false, DataSourceUpdateMode.OnPropertyChanged));
            //repeat new password
            textEditRepeatNewPassword.DataBindings.Add
                (new Binding("EditValue", viewModel, nameof(viewModel.RepeatNewPassword),false, DataSourceUpdateMode.OnPropertyChanged));
            //enable/disable "Change Password"
            simpleButtonChangePassword.DataBindings.Add
                (new Binding("Enabled", viewModel, nameof(viewModel.CanChangePassword)));
            //Password mismatch message label
            labelControlMessage.DataBindings.Add
                (new Binding("Visible", viewModel, nameof(viewModel.ShowMismatchMessage)));
        }

    }
}