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

            var simpleTypes = new List<dynamic>()
            {
                 new GenderModel(),
                 new AtollIslandModel(),
                 new SitesModel(),
                 new CountryModel(),
                 new ClinicalDetailsModel(),
                 new TestsModel()
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

                return returnData;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}
