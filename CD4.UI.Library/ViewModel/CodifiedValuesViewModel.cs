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

        public event EventHandler<String> PushingLogs;
        public event EventHandler<string> PushingMessages;

        #region default constructor
        public CodifiedResultsViewModel()
        {
            CodifiedValuesList = new BindingList<CodifiedResultsModel>();
            this.SelectedRow = new CodifiedResultsModel() { Id = null, CodifiedValue = null };

            this.SelectedRow.PropertyChanged += SelectedRow_PropertyChanged;

            InitializeDemoCodifiedData();
        }

        private void SelectedRow_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Debug.WriteLine($"Field changed: {e.PropertyName}");
        }

        #endregion

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

        public BindingList<CodifiedResultsModel> CodifiedValuesList { get; set; }
        public CodifiedResultsModel SelectedRow { get; set; }

        public void ChangeDisplayedCodifiedData(int selectedId)
        {
            var selectedRow = this.CodifiedValuesList.SingleOrDefault(c => c.Id == selectedId);
            this.SelectedRow.Id = selectedRow.Id;
            this.SelectedRow.CodifiedValue = selectedRow.CodifiedValue;
        }

        public void SavePhrase(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(SelectedRow.CodifiedValue)) 
            {
                PushingMessages?.Invoke(this, "Cannot save a blank!");
                return;
            }
            if (IsDublicatedSubmitted(SelectedRow.CodifiedValue))
            {
                PushingMessages?.Invoke(this, $"{SelectedRow.CodifiedValue} is already in the system");
                return;
            }

            //Save from here.
            PushingMessages?.Invoke(this, $"{SelectedRow.CodifiedValue} is saved.");

        }

        private bool IsDublicatedSubmitted(string codifiedValue)
        {
            var phrase = CodifiedValuesList.SingleOrDefault(p => p.CodifiedValue == codifiedValue);
            if (phrase is null) return false;
            return true;
        }
    }
}