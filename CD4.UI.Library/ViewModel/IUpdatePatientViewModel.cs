using CD4.UI.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public interface IUpdatePatientViewModel
    {
        string Address { get; set; }
        List<AtollModel> Atolls { get; set; }
        DateTime? Birthdate { get; set; }
        string Fullname { get; set; }
        List<GenderModel> Gender { get; set; }
        List<IslandModel> Islands { get; set; }
        List<CountryModel> Nationalities { get; set; }
        int NationalityId { get; set; }
        string NidPp { get; set; }
        string PhoneNumber { get; set; }
        string SelectedAtoll { get; set; }
        int SelectedGenderId { get; set; }
        string SelectedIsland { get; set; }
        int SelectedNationalityId { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        Task LoadPatientByNidPp();
        Task UpdatePatientAsync();
    }
}