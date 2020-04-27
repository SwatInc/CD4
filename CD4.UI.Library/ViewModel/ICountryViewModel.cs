using CD4.UI.Library.Model;
using System;
using System.ComponentModel;

namespace CD4.UI.Library.ViewModel
{
    public interface ICountryViewModel
    {
        BindingList<CountryModel> CountryList { get; set; }
        CountryModel SelectedRow { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
        event EventHandler<string> PushingLogs;
        event EventHandler<string> PushingMessages;

        void DisplaySelectedCountryData(int selectedId);
        void SaveCountry(object sender, EventArgs e);
    }
}