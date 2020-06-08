using DevExpress.XtraEditors;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CD4.UI.View
{
    public partial class AuthenticationView : DevExpress.XtraEditors.XtraForm
    {
        //Holds the current UI state
        private UiState uiState;
        public AuthenticationView()
        {
            InitializeComponent();
            
            //Set Ui State to normal
            SetNormalUiState();

            //subscribe for events
            simpleButtonCancel.Click += CloseSignInView;
            SimpleButtonSignIn.Click += SignInUser;
            this.FormClosing += OnClosingSignIn;
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