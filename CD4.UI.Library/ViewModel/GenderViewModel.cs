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
    public class GenderViewModel : INotifyPropertyChanged, IGenderViewModel
    {
        public event EventHandler<String> PushingLogs;
        public event EventHandler<string> PushingMessages;

        public GenderViewModel()
        {
            this.GenderList = new BindingList<GenderModel>();
            this.SelectedRow = new GenderModel();

            InitializeDemoData();
        }

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public BindingList<GenderModel> GenderList { get; set; }
        public GenderModel SelectedRow { get; set; }

        public void DisplaySelectedData(int selectedId)
        {
            var selectedRow = this.GenderList.SingleOrDefault(c => c.Id == selectedId);
            this.SelectedRow.Id = selectedRow.Id;
            this.SelectedRow.Gender = selectedRow.Gender;
        }

        private void InitializeDemoData()
        {
            var male = new GenderModel() { Id = 1, Gender = "MALE" };
            var female = new GenderModel() { Id = 2, Gender = "FEMALE" };
            var unknown = new GenderModel() { Id = 3, Gender = "UNKNOWN" };

            GenderList.Add(male);
            GenderList.Add(female);
            GenderList.Add(unknown);
        }

        public void SaveGender(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedRow.Gender))
            {
                PushingMessages?.Invoke(this, "Cannot save a blank!");
                return;
            }
            if (IsDublicatedSubmitted(SelectedRow.Gender))
            {
                PushingMessages?.Invoke(this, $"{SelectedRow.Gender} is already in the system");
                return;
            }

            //Save from here.
            PushingMessages?.Invoke(this, $"{SelectedRow.Gender} is saved.");

        }

        private bool IsDublicatedSubmitted(string gender)
        {
            var SearchCountry = GenderList.SingleOrDefault(p => p.Gender == gender);
            if (SearchCountry is null) return false;
            return true;
        }
    }
}
