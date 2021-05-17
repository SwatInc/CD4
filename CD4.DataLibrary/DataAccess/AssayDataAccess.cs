using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    /// <summary>
    /// Creats, reads and updates records for dbo.Test
    /// This class is named AssayDataAccess instead of TestDataAccess to avoid possible confusion of the word test
    /// </summary>
    public class AssayDataAccess : DataAccessBase, IAssayDataAccess
    {
        public async Task<List<TestsModel>> GetAllAssaysAsync()
        {
            var storedProcedure = "usp_GetAllTestsForConfiguration";
            try
            {
                var assays = await LoadDataAsync<TestsModel>(storedProcedure);
                return assays;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TestsModel> InsertTestAsync(TestsInsertModel assayToInsert)
        {
            try
            {
                var storedProcedure = "[dbo].[usp_InsertTest]";
                var output = await SelectInsertOrUpdateAsync<TestsModel, TestsInsertModel>(storedProcedure, assayToInsert);
                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
