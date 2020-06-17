using CD4.UI.Library.ViewModel;
using DevExpress.XtraEditors;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CD4.UI.View
{
    public partial class AuthenticationView : XtraForm
    {
        //Holds the current UI state
        private UiState uiState;
        private bool? capsLockStatus;
        private readonly IAuthenticationViewModel viewModel;

        //events 
        private event EventHandler<bool> CapsLockStatusChanged;
        
        public AuthenticationView(IAuthenticationViewModel viewModel)
        {
            InitializeComponent();
           
            //subscribe for events
            simpleButtonCancel.Click += CloseSignInView;
            SimpleButtonSignIn.Click += SignInUser;
            CapsLockStatusChanged += AuthenticationView_CapsLockStatusChanged;
            FormClosing += OnClosingSignIn;
            KeyUp += AuthenticationView_KeyUp;

            //Set Ui State to normal
            SetNormalUiState();

            //initialize caps locks status display on view
            CheckCapsLockStatus();
            this.viewModel = viewModel;

            //bind UI to view model
            InitializeBinding();

        }

        private void InitializeBinding()
        {
            //bind username
            textEditUsername.DataBindings.Add
                (new Binding("EditValue", viewModel, nameof(viewModel.Username)));

            //bind password
            textEditPassword.DataBindings.Add
                (new Binding("EditValue", viewModel, nameof(viewModel.Password)));

            //bind login button disable / enable functionality
            SimpleButtonSignIn.DataBindings.Add
                (new Binding("Enabled", viewModel, nameof(viewModel.CanLogIn)));
        }

        //reflect the caps lock status on view
        private void AuthenticationView_CapsLockStatusChanged(object sender, bool e)
        {
            this.labelControlCapsLockStatus.Visible = e;
        }

        private void AuthenticationView_KeyUp(object sender, KeyEventArgs e)
        {
            //check caps lock status
            CheckCapsLockStatus();
        }

        /// <summary>
        /// Handles user authenitcation button click
        /// </summary>
        private async void SignInUser(object sender, EventArgs e)
        {
            ToggleUiState();
            //initialize auth async
            await Task.Delay(3000);
            ToggleUiState();
        }

        /// <summary>
        /// Handle FormClosing event to verify whether the user intends to exit application
        /// </summary>
        private void OnClosingSignIn(object sender, FormClosingEventArgs e)
        {
            //Ask for confirmation. 
            if (XtraMessageBox.Show(this.LookAndFeel,this, "Do you want to quit the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                //Cancel form close
                e.Cancel = true;
                return;
            }

            //Exit application
            ExitApplication();
        }

        /// <summary>
        /// When called, checks the current caps lock status with the previous and raises an event if status is changed.
        /// </summary>
        private void CheckCapsLockStatus()
        {
            //check current caps lock status
            bool? currentCapsLockStatus = Control.IsKeyLocked(Keys.CapsLock);
            //Compare caps lock status, return if current status is same as previous
            if (currentCapsLockStatus == capsLockStatus) return;
            //assign new caps lock status
            capsLockStatus = currentCapsLockStatus;
            //Raise event to indicate the change
            CapsLockStatusChanged?.Invoke(this, (bool)capsLockStatus);
        }

        /// <summary>
        /// Calls this views close function
        /// </summary>
        private void CloseSignInView(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Exits the application
        /// </summary>
        private void ExitApplication()
        {
            //return 0 to OS on exit.
            Environment.Exit(0);
        }

        /// <summary>
        /// enum Ui states
        /// </summary>
        private enum UiState
        {
            Normal,
            Authenticating
        }

        /// <summary>
        /// Toggles the UI state of the view between normal and authenticating
        /// </summary>
        public void ToggleUiState()
        {
            //Toggle the UI state between Normal and Authentcating depending on the current state
            if (uiState == UiState.Normal) { SetAuthenticatingUiState(); return; }
            SetNormalUiState();
        }

        /// <summary>
        /// use to set UI state to normal. 
        /// Do not call this directly except on constructor. Use ToggleUiState instead.
        /// </summary>
        private void SetNormalUiState()
        {
            //if UI state is already normal, ignore and return
            if (uiState == UiState.Normal) { return; }

            //hide and undock the progress panel, in order
            ProgressPanelAuthentication.Visible = false;
            ProgressPanelAuthentication.Dock = DockStyle.None;

            //enable buttons and textedits
            SimpleButtonSignIn.Enabled = true;
            simpleButtonCancel.Enabled = true;
            textEditUsername.Enabled = true;
            textEditPassword.Enabled = true;

            //set the UiState flag to "normal"
            uiState = UiState.Normal;
        }
        private void SetAuthenticatingUiState()
        {
            //if UI state is already normal, ignore and return
            if (uiState == UiState.Authenticating) { return; }

            //dock-fill and show the progress panel, in order
            ProgressPanelAuthentication.Dock = DockStyle.Fill;
            ProgressPanelAuthentication.Visible = true;

            //disable buttons and textedits to prevent possible accidental inputs
            SimpleButtonSignIn.Enabled = false;
            simpleButtonCancel.Enabled = false;
            textEditUsername.Enabled = false;
            textEditPassword.Enabled = false;

            //set the UiState flag to "normal"
            uiState = UiState.Authenticating;
        }
    }
}