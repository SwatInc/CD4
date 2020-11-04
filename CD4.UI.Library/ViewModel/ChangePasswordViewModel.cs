using CD4.DataLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace CD4.UI.Library.ViewModel
{
    public class ChangePasswordViewModel : INotifyPropertyChanged, IChangePasswordViewModel
    {
        private string repeatNewPassword;
        private string newPassword;
        private string currentPassword;
        private readonly IAuthenticationDataAccess _authenticationDataAccess;

        public event EventHandler<string> PrompToView;
        public ChangePasswordViewModel(IAuthenticationDataAccess authenticationDataAccess)
        {

            //subscribe for events
            PropertyChanged += ActOnLocalPropertyChanged;
            _authenticationDataAccess = authenticationDataAccess;
        }

        private void ActOnLocalPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //Enable or disable CanChangePassword
            DetermineCanChangePassword();
            //Determine when to show New passwords mismatch
            DetermineShowNewPasswordMismatchMessage();
        }

        /// <summary>
        /// displays password mismatch message appropriately.
        /// </summary>
        private void DetermineShowNewPasswordMismatchMessage()
        {
            //If either of the new passwords are not entered, hide the message
            if (string.IsNullOrEmpty(NewPassword) || string.IsNullOrEmpty(RepeatNewPassword))
            {
                ShowMismatchMessage = false;
                return;
            }
            //If new pass and repeated pass match, hide the message
            if (NewPassword==RepeatNewPassword)
            {
                ShowMismatchMessage = false;
                return;
            }
            //show the message
            ShowMismatchMessage = true;
        }

        /// <summary>
        /// Determines whether the "Change Password" button on the UI is enabled
        /// depending on the imput.
        /// </summary>
        private void DetermineCanChangePassword()
        {
            //check if current password is provided.
            if (string.IsNullOrEmpty(CurrentPassword))
            {
                //Keep the button disabled
                CanChangePassword = false;
                return;
            }
            //if passwords does not match or new password not provided...
            if ((NewPassword != RepeatNewPassword) || (string.IsNullOrEmpty(NewPassword)))
            {
                //button not enabled
                CanChangePassword = false;
                return;
            }
            //all checks passed, enable the button
            CanChangePassword = true;
        }

        public string CurrentPassword
        {
            get => currentPassword; set
            {
                if (currentPassword == value)
                {
                    return;
                }
                currentPassword = value;
                OnPropertyChanged();
            }
        }
        public string NewPassword
        {
            get => newPassword; set
            {
                if (newPassword == value)
                {
                    return;
                }
                newPassword = value;
                OnPropertyChanged();
            }
        }
        public string RepeatNewPassword
        {
            get => repeatNewPassword; set
            {
                if (repeatNewPassword == value)
                {
                    return;
                }
                repeatNewPassword = value;
                OnPropertyChanged();
            }
        }
        public bool CanChangePassword { get; set; }
        public bool ShowMismatchMessage { get; set; }
        public string LoggedInUserName { get; set; }
        public async Task ChangePassword()
        {
            try
            {
                await _authenticationDataAccess.ChangePassword(CurrentPassword, LoggedInUserName, NewPassword);
                PrompToView?.Invoke(this, "Password changed successfully!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
