using CD4.DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface ISampleDataAccess
    {
        Task<SampleAndResultStatusAndResultModel> CancelSampleRejectionByCinAsync(string cin, int userId);
        Task<List<AuditTrailModel>> GetAuditTrailByCinAsync(string cin);
        Task<SampleAndResultStatusAndResultModel> RejectSampleAsync(string cin, int commentListId, int userId);
        Task<bool> UpdateSample(SampleUpdateDatabaseModel sample, int loggedInUserId);
    }
}