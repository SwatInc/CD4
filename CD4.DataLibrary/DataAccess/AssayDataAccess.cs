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

        public async Task<TestsModel> AssayUpdateAsync(TestUpdateModel assayToUpdate)
        {
            try
            {
                var storedProcedure = "[dbo].[usp_UpdateTestById]";
                var parameters = new 
                {
                    Id = assayToUpdate.Id,
                    DisciplineId = assayToUpdate.DisciplineId,
                    Description = assayToUpdate.Description,
                    SampleTypeId = assayToUpdate.SampleTypeId,
                    ResultDataTypeId = assayToUpdate.ResultDataTypeId,
                    Mask = assayToUpdate.Mask,
                    UnitId = assayToUpdate.UnitId,
                    Reportable = assayToUpdate.Reportable,
                    Code = assayToUpdate.Code,
                    DefaultCommented = assayToUpdate.DefaultCommented,
                    SortOrder = assayToUpdate.SortOrder,
                    PrimaryHeader = assayToUpdate.PrimaryHeader,
                    SecondaryHeader = assayToUpdate.SecondaryHeader
                };

                var output = await SelectInsertOrUpdateAsync<TestsModel, dynamic>(storedProcedure, parameters);
                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
