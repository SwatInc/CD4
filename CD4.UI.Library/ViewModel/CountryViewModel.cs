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
    public class CountryViewModel : INotifyPropertyChanged, ICountryViewModel
    {
        public event EventHandler<String> PushingLogs;
        public event EventHandler<string> PushingMessages;

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public BindingList<CountryModel> CountryList { get; set; }
        public CountryModel SelectedRow { get; set; }

        public void DisplaySelectedCountryData(int selectedId)
        {
            var selectedRow = this.CountryList.SingleOrDefault(c => c.Id == selectedId);
            this.SelectedRow.Id = selectedRow.Id;
            this.SelectedRow.Country = selectedRow.Country;

        }

        public void SaveCountry(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedRow.Country))
            {
                PushingMessages?.Invoke(this, "Cannot save a blank!");
                return;
            }
            if (IsDublicatedSubmitted(SelectedRow.Country))
            {
                PushingMessages?.Invoke(this, $"{SelectedRow.Country} is already in the system");
                return;
            }

            //Save from here.
            PushingMessages?.Invoke(this, $"{SelectedRow.Country} is saved.");

        }

        private bool IsDublicatedSubmitted(string country)
        {
            var SearchCountry = CountryList.SingleOrDefault(p => p.Country == country);
            if (SearchCountry is null) return false;
            return true;
        }
    }
}
