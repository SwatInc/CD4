using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class SampleDataAccess : DataAccessBase, ISampleDataAccess
    {
        public async Task<bool> UpdateSample(SampleUpdateDatabaseModel sample)
        {
            var storedProcedure = "[dbo].[usp_UpdateSampleWithCin]";
            return await SelectInsertOrUpdateAsync<bool, SampleUpdateDatabaseModel>(storedProcedure, sample);
        }

        public async Task<List<AuditTrailModel>> GetAuditTrailByCinAsync(string cin)
        {
            var storedProcedure = "[dbo].[usp_GetAuditTrailByCin]";
            var parameter = new { Cin = cin };
            return  await LoadDataWithParameterAsync<AuditTrailModel, dynamic>(storedProcedure, parameter);
        }

        public async Task<SampleAndResultStatusAndResultModel> RejectSampleAsync(string cin, int commentListId, int userId)
        {
            var storedProcedure = "[dbo].[usp_RejectSampleByCin]";
            var parameter = new { Cin = cin, CommentListId = commentListId, UserId = userId};
            try
            {
                var output = await QueryMultiple_GetModelAndListWithParameterAsync<StatusUpdatedSampleModel, UpdatedResultAndStatusModel,dynamic>
                    (storedProcedure, parameter);

                return new SampleAndResultStatusAndResultModel()
                {
                    SampleData = output.T1,
                    ResultStatus = output.U1
                };
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
