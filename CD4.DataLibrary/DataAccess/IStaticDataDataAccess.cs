﻿using CD4.DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IStaticDataDataAccess
    {
        Task<List<AtollIslandModel>> GetAllAtollsAndIslandsAsync();
        Task<List<ClinicalDetailsModel>> GetAllClinicalDetailsAsync();
        Task<List<CountryModel>> GetAllCountriesAsync();
        Task<List<GenderModel>> GetAllGenderAsync();
        Task<List<ProfilesAndTestModelOeModel>> GetAllProfileTestsAsync();
        Task<List<SitesModel>> GetAllSitesAsync();
        Task<List<ProfilesAndTestModelOeModel>> GetAllTestsAsync();
        void LoadAll();
    }
}