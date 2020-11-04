using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public interface IChangePasswordViewModel
    {
        bool CanChangePassword { get; set; }
        string CurrentPassword { get; set; }
        string NewPassword { get; set; }
        string RepeatNewPassword { get; set; }
        bool ShowMismatchMessage { get; set; }
        string LoggedInUserName { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
        Task ChangePassword();
    }
}