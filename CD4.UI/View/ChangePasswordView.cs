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

namespace CD4.UI.View
{
    public partial class ChangePasswordView : DevExpress.XtraEditors.XtraForm
    {
        private readonly IChangePasswordViewModel viewModel;

        public ChangePasswordView(IChangePasswordViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            InitializeBinding();
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