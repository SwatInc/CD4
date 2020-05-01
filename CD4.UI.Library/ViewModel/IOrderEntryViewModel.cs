using CD4.UI.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CD4.UI.Library.ViewModel
{
    public interface IOrderEntryViewModel
    {
        BindingList<TestModel> AddedTests { get; set; }
        string Address { get; set; }
        int? Age { get; set; }
        List<TestModel> AllTestsData { get; set; }
        List<AtollModel> Atolls { get; set; }
        DateTime? Birthdate { get; set; }
        string Cin { get; set; }
        BindingList<ClinicalDetailsOrderEntryModel> ClinicalDetails { get; set; }
        List<CountryModel> Countries { get; set; }
        string EpisodeNumber { get; set; }
        string Fullname { get; set; }
        List<GenderModel> Gender { get; set; }
        List<IslandModel> Islands { get; set; }
        string NidPp { get; set; }
        string PhoneNumber { get; set; }
        DateTime? SampleCollectionDate { get; set; }
        DateTime? SampleReceivedDate { get; set; }
        AtollModel SelectedAtoll { get; set; }
        CountryModel SelectedCountry { get; set; }
        int SelectedGenderId { get; set; }
        IslandModel SelectedIsland { get; set; }
        int SelectedSiteId { get; set; }
        List<SitesModel> Sites { get; set; }
        TestModel TestToAdd { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}