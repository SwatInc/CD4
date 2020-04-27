using CD4.UI.Library.Model;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CD4.UI.Library.ViewModel
{
    public class CodifiedResultsViewModel : ICodifiedResultsViewModel, INotifyPropertyChanged
    {
        private State _userInputState;
        private bool isTextEditIdEnabled;
        private bool isTextEditCodifiedResultEnabled;
        private bool isButtonSaveEnabled;
        private bool isButtonEditEnabled;

        public event EventHandler<String> PushingLogs;

        #region default constructor
        public CodifiedResultsViewModel()
        {
            CodifiedValuesList = new BindingList<CodifiedResultsModel>();
            this.SelectedRow = new CodifiedResultsModel() { Id = null, CodifiedValue = null };
            this.PreviousRow = new CodifiedResultsModel() { Id = null, CodifiedValue = null };
            this.UserInputState = State.Initialized;

            //Subscribe for events
            this.SelectedRow.PropertyChanged += HandlingOwnEventsForBehaviour;
            this.PropertyChanged += HandlingOwnEventsForBehaviour;

            InitializeDemoCodifiedData();
        }

        #endregion

        private void HandlingOwnEventsForBehaviour(object sender, PropertyChangedEventArgs e)
        {
            //Managing user imput UI state
            if (e.PropertyName == nameof(this.SelectedRow.Id) || e.PropertyName == nameof(this.SelectedRow.CodifiedValue))
            {
                PushingLogs?.Invoke(this, $"Updating {nameof(CodifiedResultsViewModel)}.{nameof(UserInputState)} change. Property changed: {e.PropertyName}");
                ManageUserInputState();
            }

            if (e.PropertyName == nameof(UserInputState)) 
            {
                Debug.WriteLine(UserInputState.ToString());
                ManagerUIState();
            }
        }

        private void ManageUserInputState()
        {
            switch (UserInputState)
            {
                case State.Initialized:
                    break;
                case State.Fresh:
                    break;
                case State.Dirty:
                    break;
                case State.Clean:
                    if (PreviousRow == SelectedRow)
                    {
                        this.UserInputState = State.Clean;
                    }
                    else
                    {
                        UserInputState = State.Dirty;
                    }
                    break;
                default:
                    break;
            }
        }

        private void ManagerUIState()
        {
            switch (UserInputState)
            {
                case State.Initialized:

                    break;
                case State.Fresh:
                    break;
                case State.Dirty:
                    break;
                case State.Clean:
                    EnableCleanUISetup();
                    break;
                default:
                    break;
            }

        }

        private void EnableCleanUISetup()
        {
            Debug.WriteLine($"Executing UI state changes. Programattic State {UserInputState}");

            this.IsButtonEditEnabled = true;
            this.IsButtonSaveEnabled = false;
            this.IsTextEditIdEnabled = false;
            this.IsTextEditCodifiedResultEnabled = false;

            Debug.WriteLine($"Executed UI state changes. Programattic State {UserInputState}");
        }

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private void InitializeDemoCodifiedData()
        {
            var dataOne = new CodifiedResultsModel()
            {
                Id = 1,
                CodifiedValue = "POSITIVE"
            };
            var dataTwo = new CodifiedResultsModel()
            {
                Id = 2,
                CodifiedValue = "NEGATIVE"
            };
            var dataThree = new CodifiedResultsModel()
            {
                Id = 3,
                CodifiedValue = "DETECTED"
            };
            var dataFour = new CodifiedResultsModel()
            {
                Id = 4,
                CodifiedValue = "NOT DETECTED"
            };

            this.CodifiedValuesList.Add(dataOne);
            this.CodifiedValuesList.Add(dataTwo);
            this.CodifiedValuesList.Add(dataThree);
            this.CodifiedValuesList.Add(dataFour);

        }

        #region Properties

        public BindingList<CodifiedResultsModel> CodifiedValuesList { get; set; }
        public CodifiedResultsModel SelectedRow { get; set; }
        public CodifiedResultsModel PreviousRow { get; set; }
        public State UserInputState
        {
            get => _userInputState; set
            {
                if (_userInputState == value) return;
                _userInputState = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region UI state Properies
        public bool IsTextEditIdEnabled
        {
            get => isTextEditIdEnabled; set
            {
                if (isTextEditIdEnabled == value) return;
                isTextEditIdEnabled = value;
                OnPropertyChanged();
            }
        }
        public bool IsTextEditCodifiedResultEnabled
        {
            get => isTextEditCodifiedResultEnabled; set
            {
                if (isTextEditCodifiedResultEnabled == value) return;
                isTextEditCodifiedResultEnabled = value;
                OnPropertyChanged();
            }
        }
        public bool IsButtonSaveEnabled
        {
            get => isButtonSaveEnabled; set
            {
                if (isButtonSaveEnabled == value) return;
                isButtonSaveEnabled = value;
                OnPropertyChanged();
            }
        }
        public bool IsButtonEditEnabled
        {
            get => isButtonEditEnabled; set
            {
                if (isButtonEditEnabled == value) return;
                isButtonEditEnabled = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public void ChangeDisplayedCodifiedData(int selectedId)
        {
            this.PreviousRow.Id = this.SelectedRow.Id;
            this.PreviousRow.CodifiedValue = this.SelectedRow.CodifiedValue;

            var selectedRow = this.CodifiedValuesList.SingleOrDefault(c => c.Id == selectedId);
            this.SelectedRow.Id = selectedRow.Id;
            this.SelectedRow.CodifiedValue = selectedRow.CodifiedValue;
            this.UserInputState = State.Clean;


        }


    }
}
