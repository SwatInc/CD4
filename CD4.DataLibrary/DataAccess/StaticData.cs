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
    public class StaticData : DataAccessBase
    {
        public void LoadAll()
        {
        }

        private List<T> LoadStaticData<T>(string storedProcedure)
        {
            List<T> results = new List<T>();
            using (IDbConnection connection = new SqlConnection(helper.GetConnectionString()))
            {
                results = connection.Query<T>(storedProcedure, CommandType.StoredProcedure).ToList();
            }

            return results;
        }

        /// <summary>
        /// NOTE: T should be the first type of data set returned by the query / procedure
        /// NOTE: U should be the second type of data set returned by the query / procedure
        /// MEANS that the generic classes should be passed in the order that is expected to be returned by the query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="storedProcedure"></param>
        /// <returns>returns a class with List<T> AND List<U> as public properties</returns>
        private async Task<GenericTwoListModel> LoadStaticDataTwoSetsAsync<T, U>(string storedProcedure)
        {
            var genericTwoList = new GenericTwoListModel();
            var returnData = genericTwoList.GetLists<T, U>();

            List<T> ListT = null;
            List<U> ListU = null;

            using (IDbConnection connection = new SqlConnection(helper.GetConnectionString()))
            {
                using (var lists = await connection.QueryMultipleAsync(storedProcedure, CommandType.StoredProcedure))
                {
                    ListT = lists.Read<T>().ToList();
                    ListU = lists.Read<U>().ToList();
                }
            }

            returnData.T1 = ListT;
            returnData.U1 = ListU;
            return returnData;
        }


        public List<SitesModel> GetAllSites()
        {
            string storedProcedure = "usp_GetAllSites";
            try
            {
                return LoadStaticData<SitesModel>(storedProcedure);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<CountryModel> GetAllCountries()
        {
            string storedProcedure = "usp_GetAllCountries";
            try
            {
                return LoadStaticData<CountryModel>(storedProcedure);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<GenderModel> GetAllGender()
        {
            string storedProcedure = "usp_GetAllGenders";
            try
            {
                return LoadStaticData<GenderModel>(storedProcedure);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<AtollIslandModel> GetAllAtollsAndIslands()
        {
            string storedProcedure = "usp_GetAllAtollAndIslands";
            try
            {
                return LoadStaticData<AtollIslandModel>(storedProcedure);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ClinicalDetailsModel> GetAllClinicalDetails()
        {
            string storedProcedure = "usp_GetAllClinicalDetails";
            try
            {
                return LoadStaticData<ClinicalDetailsModel>(storedProcedure);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ProfilesAndTestModelOeModel> GetAllTests()
        {
            string storedProcedure = "[usp_GetAllTests]";
            try
            {
                return LoadStaticData<ProfilesAndTestModelOeModel>(storedProcedure);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ProfilesAndTestModelOeModel>> GetAllProfileTests()
        {
            string storedProcedure = "[usp_GetAllProfilesAndProfileTests]";
            try
            {
                var results = await LoadStaticDataTwoSetsAsync
                    <ProfileDatabaseModel, ProfileTestsDatabaseModel>(storedProcedure);
                return await GetProfileAndTestOeModelFromSearchResults(results);
            }
            catch (Exception)
            {

                throw;
            }
        }


        private async Task<List<ProfilesAndTestModelOeModel>> GetProfileAndTestOeModelFromSearchResults
            (GenericTwoListModel searchResults)
        {
            var profileAndTestOeDataList = new List<ProfilesAndTestModelOeModel>();
            var profiles = (List<ProfileDatabaseModel>)searchResults.T1; //Liver
            var ProfileTests = (List<ProfileTestsDatabaseModel>)searchResults.U1; //TBIL, DBIL, ....

            return  await Task.Run(() =>
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

    }
}
