using CD4.DataLibrary.Models;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class ReferenceRangeDataAccess : DataAccessBase, IReferenceRangeDataAccess
    {
        public async Task<ResultReferenceRangeModel> GetReferenceRangeByResultIdAsync(int resultId)
        {
            var storedProcedure = "[dbo].[usp_GetResultReferenceRangeByResultId]";
            var parameter = new { ResultId = resultId };
            try
            {
                return await SelectInsertOrUpdateAsync<ResultReferenceRangeModel, dynamic>(storedProcedure, parameter);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
