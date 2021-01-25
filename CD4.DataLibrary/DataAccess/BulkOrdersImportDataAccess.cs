using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class BulkOrdersImportDataAccess : DataAccessBase, IBulkOrdersImportDataAccess
    {
        public async Task<BulkImportsStaticDataModel> GetAllStaticDataForBulkImport()
        {
            var storedProcedure = "[dbo].[usp_LoadStaticDataForBulkImport]";
            var returnData = new BulkImportsStaticDataModel();
            var types = new TypesModel();

            types.GenericModelsList.Add(returnData.Genders.GetType());
            types.GenericModelsList.Add(returnData.AtollsAndIslands.GetType());
            types.GenericModelsList.Add(returnData.Sites.GetType());
            types.GenericModelsList.Add(returnData.Countries.GetType());
            types.GenericModelsList.Add(returnData.ClinicalDetails.GetType());
            types.GenericModelsList.Add(returnData.Tests.GetType());
            types.GenericModelsList.Add(returnData.ProfileTests.GetType());
            types.GenericModelsList.Add(returnData.Tests.GetType());

            var simpleTypes = new List<dynamic>()
            {
                 new GenderModel(),
                 new AtollIslandModel(),
                 new SitesModel(),
                 new CountryModel(),
                 new ClinicalDetailsModel(),
                 new ProfilesAndTestModelOeModel(),
                 new ProfileTestsDatabaseModel(),
                 new ProfilesAndTestModelOeModel()
            };

            try
            {
                var results = await QueryMultiple_WithProvidedReturnTypes_NoParameters(storedProcedure, types, simpleTypes);

                foreach (var item in results[0])
                {
                    returnData.Genders.Add(item);
                }
                foreach (var item in results[1])
                {
                    returnData.AtollsAndIslands.Add(item);
                }
                foreach (var item in results[2])
                {
                    returnData.Sites.Add(item);
                }
                foreach (var item in results[3])
                {
                    returnData.Countries.Add(item);
                }
                foreach (var item in results[4])
                {
                    returnData.ClinicalDetails.Add(item);
                }
                foreach (var item in results[5])
                {
                    returnData.Tests.Add(item);
                }
                foreach (var item in results[6])
                {
                    var profileTest = (ProfileTestsDatabaseModel)item;
                    var profile = returnData.Tests.Find((x) => x.Id == profileTest.ProfileId);
                    profile.TestsInProfile.Add(new TestsModel()
                    {
                        Id = profileTest.TestId,
                        Description = profileTest.Test,
                        Mask = profileTest.Mask,
                        ResultDataType = profileTest.ResultDataType,
                        IsReportable = profileTest.IsReportable
                    });
                }
                foreach (var item in results[7])
                {
                    returnData.Tests.Add(item);
                }


                return returnData;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// searches the database and return the number 
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public async Task<string> GetCinForImportedHash(int hash)
        {
            var storedProcedure = "[dbo].[usp_GetCinForImportHash]";
            var parameter = new { Hash = hash };

            try
            {
                return await SelectInsertOrUpdateAsync<string, dynamic>(storedProcedure, parameter);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task InsertHash(int recordHash, string cin)
        {
            var storedProcedure = "[dbo].[usp_InsertImportRecordHash]";
            var parameter = new { Cin = cin, Hash = recordHash };

            try
            {
                await SelectInsertOrUpdateAsync<int, dynamic>(storedProcedure, parameter);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
