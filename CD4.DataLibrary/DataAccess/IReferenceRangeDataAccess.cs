using CD4.DataLibrary.Models;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IReferenceRangeDataAccess
    {
        Task<ResultReferenceRangeModel> GetDemoReferenceRangeByResultIdAsync(int resultId);
        Task<ResultReferenceRangeModel> GetReferenceRangeByResultIdAsync(int resultId);
    }
}