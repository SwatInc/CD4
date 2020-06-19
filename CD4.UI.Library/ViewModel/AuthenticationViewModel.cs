using AutoMapper;
using CD4.DataLibrary.DataAccess;
using CD4.UI.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public class AuthenticationViewModel : IAuthenticationViewModel, INotifyPropertyChanged
    {
        private string username;
        private string password;
        private readonly IAuthenticationDataAccess authDataAccess;
        private readonly IMapper mapper;

        //Raised when auth is successful or unsuccessful 
        // TODO: Passes Authorized model to the subscriber
        public event EventHandler<AuthorizeDetailEventArgs> AuthenticationStatusIndication;
        public AuthenticationViewModel(IAuthenticationDataAccess authDataAccess, IMapper mapper)
        {
            //login button is disabled on startup
            CanLogIn = false;
            //subscribe to property changed for processing on change events
            PropertyChanged += AuthenticationViewModel_PropertyChanged;
            this.authDataAccess = authDataAccess;
            this.mapper = mapper;
        }
        
        /// <summary>
        /// Do required operation depending on a property change on the UI
        /// </summary>
        private void AuthenticationViewModel_PropertyChanged 
            (object sender, PropertyChangedEventArgs e)
        {
            //if username or password is changed...
            if (e.PropertyName == nameof(Username) || e.PropertyName == nameof(Password))
            {
                //Enable or diable the login button depending on current UI state.
                EnableDisableCanEnableLogin();
            }
        }

        /// <summary>
        /// Enable the login button if both username and password is provided.
        /// if either of them is not entered, disable the button.
        /// </summary>
        private void EnableDisableCanEnableLogin()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                CanLogIn = false;
                return;
            }
            CanLogIn = true;
        }

        //The username from view
        public string Username
        {
            get => username; set
            {
                if (username == value)
                {
                    return;
                }
                username = value;
                OnPropertyChanged();
            }
        }
        //The password from view
        public string Password
        {
            get => password; set
            {
                if (password == value)
                {
                    return;
                }
                password = value;
                OnPropertyChanged();
            }
        }

        public bool CanLogIn { get; set; }

        /// <summary>
        /// Authenticate user using username and password
        /// Raises an event (AuthenticationStatusIndication) indicating authentication status
        /// </summary>
        /// <returns>returns task</returns>
        public async Task AuthenticateUser()
        {
            //call library to authenticate the username and password
            var authorizedData = await authDataAccess.Authenticate(Username, Password);
            //check the retuned data for null...
            if (authorizedData != null)
            {
                //map the AuthorozedDetailModel to event args model
                var authArgs = mapper.Map<AuthorizeDetailEventArgs>(authorizedData);
                //raise an event to indicate authentication current status
                AuthenticationStatusIndication?.Invoke(this, authArgs);
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
