using CD4.UI.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CD4.UI.Library.ViewModel
{
    public class OrderEntryViewModel : INotifyPropertyChanged
    {
        private CultureInfo cultureInfo = new CultureInfo("en-US");
        private string cin;
        private DateTime sampleCollectionDate;
        private DateTime sampleReceivedDate;
        private string nidPp;

        public OrderEntryViewModel()
        {
        }

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Properties
        //Request Data
        public string Cin
        {
            get => cin; set
            {
                if (cin == value) return;
                cin = value;
                OnPropertyChanged();
            }
        }
        public List<SiteModel> Sites { get; set; }
        public SiteModel SelectedSite { get; set; }
        public DateTime SampleCollectionDate
        {
            get => sampleCollectionDate; set
            {
                if (sampleCollectionDate == value) return;
                sampleCollectionDate = value;
                OnPropertyChanged();
            }
        }
        public DateTime SampleReceivedDate
        {
            get => sampleReceivedDate; set
            {
                if (sampleReceivedDate == value) return;
                sampleReceivedDate = value;
                OnPropertyChanged();
            }
        }

        //Patient Data
        public string NidPp
        {
            get => nidPp; set
            {
                if (nidPp == value) return;
                nidPp = value;
                OnPropertyChanged();
            }
        }
        public string Fullname { get; set; }
        public List<GenderModel> Gender { get; set; }
        public GenderModel SelectedGender { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public List<AtollModel> Atolls { get; set; }
        public AtollModel SelectedAtoll { get; set; }
        public List<IslandModel> Islands { get; set; }
        public IslandModel SelectedIsland { get; set; }
        public List<CountryModel> Countries { get; set; }
        public CountryModel SelectedCountry { get; set; }

        //ClincalDetails

        #endregion

    }


}
