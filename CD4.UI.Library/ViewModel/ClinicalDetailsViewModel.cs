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
    public class ClinicalDetailsViewModel : INotifyPropertyChanged, IClinicalDetailsViewModel
    {
        public event EventHandler<String> PushingLogs;
        public event EventHandler<string> PushingMessages;

        public ClinicalDetailsViewModel()
        {
            this.ClinicalDetailsList = new BindingList<ClinicalDetailsModel>();
            this.SelectedRow = new ClinicalDetailsModel(); 
            InitializeDemoData();
        }

        private void InitializeDemoData()
        {
            var detail = new ClinicalDetailsModel() { Id = 1, ClinicalDetail = "Fever" };
            var detail1 = new ClinicalDetailsModel() { Id = 2, ClinicalDetail = "Coungh" };
            this.ClinicalDetailsList.Add(detail);
            this.ClinicalDetailsList.Add(detail1);
        }

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public BindingList<ClinicalDetailsModel> ClinicalDetailsList { get; set; }
        public ClinicalDetailsModel SelectedRow { get; set; }

        public void DisplaySelectedClinicalDetailsData(int selectedId)
        {
            var selectedRow = this.ClinicalDetailsList.SingleOrDefault(c => c.Id == selectedId);
            this.SelectedRow.Id = selectedRow.Id;
            this.SelectedRow.ClinicalDetail = selectedRow.ClinicalDetail;

        }

        public void SaveCountry(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedRow.ClinicalDetail))
            {
                PushingMessages?.Invoke(this, "Cannot save a blank!");
                return;
            }
            if (IsDublicatedSubmitted(SelectedRow.ClinicalDetail))
            {
                PushingMessages?.Invoke(this, $"{SelectedRow.ClinicalDetail} is already in the system");
                return;
            }

            //Save from here.
            PushingMessages?.Invoke(this, $"{SelectedRow.ClinicalDetail} is saved.");

        }

        private bool IsDublicatedSubmitted(string clinicalDetail)
        {
            var Search = ClinicalDetailsList.SingleOrDefault(p => p.ClinicalDetail == clinicalDetail);
            if (Search is null) return false;
            return true;

        }
    }
}
