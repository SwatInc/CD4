using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CD4.UI.Library.ViewModel;

namespace CD4.UI.View
{
    public partial class ChangePasswordView : XtraForm
    {
        private readonly IChangePasswordViewModel viewModel;

        public ChangePasswordView(IChangePasswordViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            InitializeBinding();

            //subscribe for events
            simpleButtonChangePassword.Click += ChangePassword;
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