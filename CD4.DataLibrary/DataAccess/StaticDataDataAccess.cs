using CD4.DataLibrary.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class StaticDataDataAccess : DataAccessBase, IStaticDataDataAccess
    {
        public void LoadAll()
        {
        }
        public async Task<List<SitesModel>> GetAllSitesAsync()
        {
            string storedProcedure = "usp_GetAllSites";
            try
            {
                return await LoadDataAsync<SitesModel>(storedProcedure);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<List<CountryModel>> GetAllCountriesAsync()
        {
            string storedProcedure = "usp_GetAllCountries";
            try
            {
                return await LoadDataAsync<CountryModel>(storedProcedure);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<GenderModel>> GetAllGenderAsync()
        {
            string storedProcedure = "usp_GetAllGenders";
            try
            {
                return await LoadDataAsync<GenderModel>(storedProcedure);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<AtollIslandModel>> GetAllAtollsAndIslandsAsync()
        {
            string storedProcedure = "usp_GetAllAtollAndIslands";
            try
            {
                return await LoadDataAsync<AtollIslandModel>(storedProcedure);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<ClinicalDetailsModel>> GetAllClinicalDetailsAsync()
        {
            string storedProcedure = "usp_GetAllClinicalDetails";
            try
            {
                return await LoadDataAsync<ClinicalDetailsModel>(storedProcedure);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<ProfilesAndTestModelOeModel>> GetAllTestsAsync()
        {
            string storedProcedure = "[usp_GetAllTests]";
            try
            {
                return await LoadDataAsync<ProfilesAndTestModelOeModel>(storedProcedure);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<ProfilesAndTestModelOeModel>> GetAllProfileTestsAsync()
        {
            string storedProcedure = "[usp_GetAllProfilesAndProfileTests]";
            try
            {
                var results = await LoadStaticDataTwoSetsAsync
                    <ProfileDatabaseModel, ProfileTestsDatabaseModel>(storedProcedure);
                return await GetProfileAndTestOeModelFromSearchResultsAsync(results);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private async Task<List<ProfilesAndTestModelOeModel>> GetProfileAndTestOeModelFromSearchResultsAsync
            (GenericTwoListModel searchResults)
        {
            var profileAndTestOeDataList = new List<ProfilesAndTestModelOeModel>();
            var profiles = (List<ProfileDatabaseModel>)searchResults.T1; //Liver
            var ProfileTests = (List<ProfileTestsDatabaseModel>)searchResults.U1; //TBIL, DBIL, ....

            return await Task.Run(() =>
           {
               foreach (var profile in profiles)
               {
                   var profileAndTestOeData = new ProfilesAndTestModelOeModel();

                   profileAndTestOeData.Id = profile.Id;
                   profileAndTestOeData.Description = profile.Description;
                   profileAndTestOeData.IsProfile = profile.IsProfile;

                   //Get Tests in profile
                   var testsInProfile = ProfileTests.Where((pt) =>
                  {
                      return pt.ProfileId == profile.Id;
                  }).ToList();


                   foreach (var test in testsInProfile)
                   {
                       var readyTestsInProfile = new TestsModel()
                       {
                           Id = test.TestId,
                           Description = test.Test,
                           IsReportable = test.IsReportable,
                           Mask = test.Mask,
                           ResultDataType = test.ResultDataType
                       };

                       profileAndTestOeData.TestsInProfile.Add(readyTestsInProfile);
                   }

                   profileAndTestOeDataList.Add(profileAndTestOeData);
               }

               return profileAndTestOeDataList;
           });


        }

        /// <summary>
        /// Get a list of printer names for the workstation specified with the printer types for each
        /// </summary>
        /// <param name="workstationName">The workstation system name</param>
        /// <returns>List of CurrentWorkStationPrinter</returns>
        public async Task<List<WorkstationPrintersInfoModel>> GetWorkStationPrintersAsync(string workstationName)
        {
            //the stored procedure name to call
            var storedProcedure = "[dbo].[usp_GetWorkStationSpecificPrinters]";
            //set up the parameters for the stored procedures
            var parameters = new { WorkStationName = workstationName };

            try
            {
                //call the base method for a dapper database call
                var data = await LoadDataWithParameterAsync<WorkstationPrintersInfoModel, dynamic>(storedProcedure, parameters);
                return data;
            }
            catch (Exception)
            {
                //throw any exceptions, should be handled in UI layer
                throw;
            }
        }

        public async Task<List<CodifiedResultsModel>> GetAllCodifiedValuesAsync()
        {
            var storedProcedure = "[dbo].[usp_GetAllCodifiedValues]";
            try
            {
                return await LoadDataAsync<CodifiedResultsModel>(storedProcedure);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SitesModel> AddSite(string siteName)
        {
            var storedProcedure = "[dbo].[usp_ConfigAddSite]";
            var parameter = new { SiteName = siteName };
            try
            {
                return await SelectInsertOrUpdateAsync<SitesModel, dynamic>(storedProcedure, parameter);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<SitesModel>> LoadAllSites()
        {
            var storedProcedure = "[dbo].[usp_LoadAllSites]";
            try
            {
                return await LoadDataAsync<SitesModel>(storedProcedure);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
