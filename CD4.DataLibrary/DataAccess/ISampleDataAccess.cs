using CD4.DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface ISampleDataAccess
    {
        Task<List<AuditTrailModel>> GetAuditTrailByCinAsync(string cin);
        Task<bool> UpdateSample(SampleUpdateDatabaseModel sample);
    }
}