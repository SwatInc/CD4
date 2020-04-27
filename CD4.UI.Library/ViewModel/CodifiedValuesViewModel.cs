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
    public class CodifiedResultsViewModel : ICodifiedResultsViewModel, INotifyPropertyChanged
    {
        public CodifiedResultsViewModel()
        {
            CodifiedValuesList = new BindingList<CodifiedResultsModel>();
            this.SelectedRow = new CodifiedResultsModel() { Id = null, CodifiedValue = null };
            InitializeDemoCodifiedData();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
    }
}
