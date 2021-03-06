﻿using CD4.DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IStaticDataDataAccess
    {
        Task<SitesModel> AddSite(string siteName);
        Task<List<AtollIslandModel>> GetAllAtollsAndIslandsAsync();
        Task<List<ClinicalDetailsModel>> GetAllClinicalDetailsAsync();
        Task<List<CodifiedResultsModel>> GetAllCodifiedValuesAsync();
        Task<List<CountryModel>> GetAllCountriesAsync();
        Task<List<GenderModel>> GetAllGenderAsync();
        Task<List<ProfilesAndTestModelOeModel>> GetAllProfileTestsAsync();
        Task<List<ScientistModel>> GetAllScientistsAsync();
        Task<List<SitesModel>> GetAllSitesAsync();
        Task<List<ProfilesAndTestModelOeModel>> GetAllTestsAsync();
        Task<List<BillingTestMappingModel>> GetBillingTestCodeMappings();
        Task<List<ChannelMappingModel>> GetChannelMappingData();
        Task<List<ResultAlertModel>> GetResultAlertData();
        Task<List<WorkstationPrintersInfoModel>> GetWorkStationPrintersAsync(string workstationName);
        void LoadAll();
        Task<List<SitesModel>> LoadAllSites();
    }
}