using CD4.UI.Library.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public class OrderEntryViewModel : INotifyPropertyChanged, IOrderEntryViewModel
    {
        #region Private Properties
        private CultureInfo cultureInfo = new CultureInfo("en-US");
        private string cin;
        private DateTime? sampleCollectionDate;
        private DateTime? sampleReceivedDate;
        private string nidPp;
        private string fullname;
        private string age;
        private string phoneNumber;
        private DateTime? birthdate;
        private string address;
        private string episodeNumber;
        private int selectedSiteId;
        private int selectedGenderId;
        private int selectedAtollId;
        private int selectedIslandId;
        private int selectedCountryId;
        #endregion

        #region Default Constructor
        public OrderEntryViewModel()
        {
            Sites = new List<SitesModel>();
            Gender = new List<GenderModel>();
            Atolls = new List<AtollModel>();
            Islands = new List<IslandModel>();
            Countries = new List<CountryModel>();
            AllTestsData = new List<TestModel>();
            AddedTests = new BindingList<TestModel>();
            AllAtollsAndIsland = new List<AtollsIslandsRawModel>();
            ClinicalDetails = new BindingList<ClinicalDetailsOrderEntryModel>();

            InitializeDemoData();

            PropertyChanged += OrderEntryViewModel_PropertyChanged;
        }


        #endregion

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Public Properties

        #region General Datasources
        public List<AtollsIslandsRawModel> AllAtollsAndIsland { get; set; }

        #endregion

        #region Request
        public string Cin
        {
            get => cin; set
            {
                if (cin == value) return;
                cin = value;
                OnPropertyChanged();
            }
        }
        public List<SitesModel> Sites { get; set; }
        private SitesModel SelectedSite { get; set; }
        public int SelectedSiteId
        {
            get => selectedSiteId; set
            {
                if (selectedSiteId == value) return;
                selectedSiteId = value;
                SetSelectedSiteAsync(value).ConfigureAwait(true);
                //OnPropertyChanged(); called elsewhere
            }
        }
        public DateTime? SampleCollectionDate
        {
            get => sampleCollectionDate; set
            {
                // if (sampleCollectionDate == value) return;
                sampleCollectionDate = value;
                OnPropertyChanged();
            }
        }
        public DateTime? SampleReceivedDate
        {
            get => sampleReceivedDate; set
            {
                if (sampleReceivedDate == value) return;
                sampleReceivedDate = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Patient
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
        public int SelectedGenderId
        {
            get => selectedGenderId; set
            {
                if (selectedGenderId == value) return;
                selectedGenderId = value;
                OnPropertyChanged();
            }
        }
        public string Age
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
        public DateTime? Birthdate
        {
            get => birthdate; set
            {
                if (birthdate == value) return;
                birthdate = value;
                SetAge((DateTime)value);
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
        public int SelectedAtollId
        {
            get => selectedAtollId; set
            {
                if (selectedAtollId == value) return;
                selectedAtollId = value;
                OnPropertyChanged();
            }
        }
        public List<IslandModel> Islands { get; set; }
        public int SelectedIslandId
        {
            get => selectedIslandId; set
            {
                if (selectedIslandId == value) return;
                selectedIslandId = value;
                OnPropertyChanged();
            }
        }
        public List<CountryModel> Countries { get; set; }
        public int SelectedCountryId
        {
            get => selectedCountryId; set
            {
                if (selectedCountryId == value) return;
                selectedCountryId = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Clincal Details
        public BindingList<ClinicalDetailsOrderEntryModel> ClinicalDetails { get; set; }

        #endregion

        #region Selected Tests and Test Selection
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

        #endregion

        #region Private Methods
        private void InitializeDemoData()
        {
            //Sites
            var site1 = new SitesModel() { Id = 1, Site = "IGMH" };
            var site2 = new SitesModel() { Id = 2, Site = "FARUKOLHU" };

            this.Sites.Add(site1);
            this.Sites.Add(site2);

            //Gender
            var male = new GenderModel() { Id = 1, Gender = "MALE" };
            var female = new GenderModel() { Id = 2, Gender = "FEMALE" };
            var unknown = new GenderModel() { Id = 3, Gender = "UNKNOWN" };

            Gender.Add(male);
            Gender.Add(female);
            Gender.Add(unknown);

        }

        private void SetAge(DateTime birthdate)
        {
            Age =  DateTimeExtensions.ToAgeString(birthdate);
        }


        private void OrderEntryViewModel_PropertyChanged
            (object sender, PropertyChangedEventArgs e)
        {
            Debug.WriteLine("============= Property Change Handling START ============");
            Debug.WriteLine(e.PropertyName);
            //for debugging
            if (e.PropertyName == nameof(this.selectedSiteId))
            {
                Debug.WriteLine(JsonConvert.SerializeObject(SelectedSite, Formatting.Indented));
            }

            Debug.WriteLine("============ Property Change Handling COMPLETE ==========");
        }

        private async Task SetSelectedSiteAsync(int siteId, [CallerMemberName] string propertyName = "")
        {
            Debug.WriteLine($"called {nameof(SetSelectedSiteAsync)}");
            var site = await GetSiteByIdAsync(siteId);
            if (site is null)
            {
                Debug.WriteLine($"Search Yeilded null");
                return;
            }
            SelectedSite = site;
            Debug.WriteLine($"Selected Site: {site.Id} | {site.Site}");
            Debug.WriteLine($"Completed call to {nameof(SetSelectedSiteAsync)}");
            OnPropertyChanged(propertyName);
        }

        private async Task<SitesModel> GetSiteByIdAsync(int siteId)
        {
            Debug.WriteLine($"Searching Site by Id. SiteID {siteId}");
            return await Task.Run(() =>
            {
                return Sites.SingleOrDefault(s => s.Id == siteId);
            });
        }
        #endregion
    }


}
