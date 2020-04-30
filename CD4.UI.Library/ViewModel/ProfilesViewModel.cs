using CD4.UI.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public class ProfilesViewModel : INotifyPropertyChanged, IProfilesViewModel
    {
        #region Private Properties
        private bool dataAddControlsEnabled;
        private bool otherFunctionButtons;
        private string newProfileName;
        #endregion

        #region Events
        public event EventHandler<string> PushingLogs;
        public event EventHandler<string> PushingMessages;
        #endregion

        #region Default Constructor
        public ProfilesViewModel()
        {
            this.ProfileList = new BindingList<ProfileConfigModel>();
            this.Tests = new BindingList<ProfileConfigTestModel>();
            InitializeDemoData();
            InitializeUiState(UiState.Adding);
            InitializeUiState(UiState.Default);
        }

        #endregion

        #region Private Methods
        private void InitializeUiState(UiState uiState)
        {
            switch (uiState)
            {
                case UiState.Adding:
                    DataAddControlsEnabled = true;
                    break;
                case UiState.Default:
                    DataAddControlsEnabled = false;
                    break;
                default:
                    break;
            }
        }

        private void InitializeDemoData()
        {
            var t1 = new ProfileConfigTestModel() { Id =213, TestDescription = "TBIL" };
            var t2 = new ProfileConfigTestModel() {Id=563, TestDescription = "DBIL" };

            var p1 = new ProfileConfigModel() { Id = 1, Profile = "Liver Profile", State = State.Clean };
            var p2 = new ProfileConfigModel() { Id = 2, Profile = "Lipid Profile", State = State.Clean };

            this.Tests.Add(t1);
            this.Tests.Add(t2);


            ProfileList.Add(p1);
            ProfileList.Add(p2);
        }

        #endregion

        #region Public Properties / Fields
        public BindingList<ProfileConfigModel> ProfileList { get; set; }
        public BindingList<ProfileConfigTestModel> Tests { get; set; }
        public ProfileConfigModel SelectedProfile { get; set; }
        public ProfileConfigTestModel SelectedTest { get; set; }
        public bool DataAddControlsEnabled
        {
            get => dataAddControlsEnabled; private set
            {
                if (dataAddControlsEnabled == value) return;
                dataAddControlsEnabled = value;
                OnPropertyChanged();

                OtherFunctionButtons = !DataAddControlsEnabled;
            }
        }
        public bool OtherFunctionButtons
        {
            get => otherFunctionButtons; private set
            {
                if (otherFunctionButtons == value) return;
                otherFunctionButtons = value;
                OnPropertyChanged();
            }
        }
        public string NewProfileName
        {
            get => newProfileName; set
            {
                if (newProfileName == value) return;
                newProfileName = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Public Methods
        public void UiPrepForAddingProfile(object sender, EventArgs e)
        {
            InitializeUiState(UiState.Adding);
        }

        public void SaveProfile(object sender, EventArgs e)
        {
            InitializeUiState(UiState.Default);

            if (string.IsNullOrEmpty(newProfileName)) return;

            this.ProfileList.Add(new ProfileConfigModel()
            {
                Id = -1,
                Profile = newProfileName,
                State = State.Added
            });

            NewProfileName = null;
        }

        #endregion

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


    }

}
