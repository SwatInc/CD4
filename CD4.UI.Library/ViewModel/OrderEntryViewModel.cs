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
        private string fullname;
        private int age;
        private string phoneNumber;
        private DateTime birthdate;
        private string address;
        private string episodeNumber;

        public OrderEntryViewModel()
        {
            Sites = new List<SiteModel>();
            Gender = new List<GenderModel>();
            Atolls = new List<AtollModel>();
            Islands = new List<IslandModel>();
            Countries = new List<CountryModel>();
            ClinicalDetails = new BindingList<ClinicalDetailsOrderEntryModel>();
            AddedTests = new BindingList<TestModel>();
            AllTestsData = new List<TestModel>();


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
        public string Fullname
        {
            get => fullname; set
            {
                if (fullname == value) return;
                fullname = value;
                OnPropertyChanged();
            }
        }
        public List<GenderModel> Gender { get; set; }
        public GenderModel SelectedGender { get; set; }
        public int Age
        {
            get => age; set
            {
                if (age == value) return;
                age = value;
                OnPropertyChanged();
            }
        }
        public string PhoneNumber
        {
            get => phoneNumber; set
            {
                if (phoneNumber == value) return;
                phoneNumber = value;
                OnPropertyChanged();
            }
        }
        public DateTime Birthdate
        {
            get => birthdate; set
            {
                if (birthdate == value) return;
                birthdate = value;
                OnPropertyChanged();
            }
        }
        public string Address
        {
            get => address; set
            {
                if (address == value) return;
                address = value;
                OnPropertyChanged();
            }
        }
        public List<AtollModel> Atolls { get; set; }
        public AtollModel SelectedAtoll { get; set; }
        public List<IslandModel> Islands { get; set; }
        public IslandModel SelectedIsland { get; set; }
        public List<CountryModel> Countries { get; set; }
        public CountryModel SelectedCountry { get; set; }

        //ClincalDetails
        public BindingList<ClinicalDetailsOrderEntryModel> ClinicalDetails { get; set; }

        //Selected Tests
        public BindingList<TestModel> AddedTests { get; set; }

        //TestSelection
        public List<TestModel> AllTestsData { get; set; }
        public TestModel TestToAdd { get; set; }
        public string EpisodeNumber
        {
            get => episodeNumber; set
            {
                if (episodeNumber == value) return;
                episodeNumber = value;
                OnPropertyChanged();
            }
        }

        #endregion

    }


}
