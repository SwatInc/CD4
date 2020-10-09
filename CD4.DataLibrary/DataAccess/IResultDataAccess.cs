using CD4.DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IResultDataAccess
    {
        Task<SampleAndResultStatusAndResultModel> CancelTestRejectionByResultId(int resultId, int userId);
        Task<UpdatedResultAndStatusModel> InsertUpdateResultByResultIdAsync(int resultId, string result, int testStatus);
        Task<bool> ManageRequestedTestsDataAsync(List<TestsModel> testsToInsert, List<TestsModel> testsToRemove, string cin);
        Task<SampleAndResultStatusAndResultModel> RejectTestByResultId(int resultId, string cin, int commentListId, int userId);
    }
}