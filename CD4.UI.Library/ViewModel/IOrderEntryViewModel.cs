using CD4.UI.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public interface IOrderEntryViewModel
    {
        BindingList<TestModel> AddedTests { get; set; }

        bool LoadingStaticDataStatus { get; set; }
        string Address { get; set; }
        string Age { get; set; }
        List<ProfilesAndTestsDatasourceOeModel> AllTestsData { get; set; }
        List<AtollModel> Atolls { get; set; }
        DateTime? Birthdate { get; set; }
        string Cin { get; set; }
        string CinErrorText { get; set; }
        BindingList<ClinicalDetailsOrderEntryModel> ClinicalDetails { get; set; }
        List<CountryModel> Countries { get; set; }
        string EpisodeNumber { get; set; }
        string Fullname { get; set; }
        List<GenderModel> Gender { get; set; }
        BindingList<IslandModel> Islands { get; set; }
        string NidPp { get; set; }
        string PhoneNumber { get; set; }
        DateTime? SampleCollectionDate { get; set; }
        DateTime? SampleReceivedDate { get; set; }
        int SelectedAtollId { get; set; }
        int SelectedCountryId { get; set; }
        int SelectedGenderId { get; set; }
        int SelectedIslandId { get; set; }
        int SelectedSiteId { get; set; }
        List<SitesModel> Sites { get; set; }
        string TestToAdd { get; set; }
        Task ManageAddTestToRequestAsync();
        void RemoveTestModelFromAddedTests(TestModel testModel);
        Task OnReceiveSearchResults(PatientModel results);

        event PropertyChangedEventHandler PropertyChanged;
        event EventHandler<string> PushingLogs;
        event EventHandler<string> PushingMessages;
    }
}