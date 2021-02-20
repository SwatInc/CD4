using CD4.DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IResultDataAccess
    {
        Task<SampleAndResultStatusAndResultModel> CancelResultValidation(int resultId, string cin, int userId);
        Task<SampleAndResultStatusAndResultModel> CancelTestRejectionByResultId(int resultId, int userId);
        Task<List<UpdatedResultAndStatusModel>> GetResultAndResultStatusDataByCin(string cin);
        Task<List<ResultHistoryModel>> GetResultHistoryAync(int resultId, int analysisRequestId);
        Task<UpdatedResultAndStatusModel> InsertUpdateResultByResultIdAsync(int resultId, string result, int testStatus, int userId);
        Task<UpdatedResultAndStatusModel> InterfaceUpdateResultByTestIdAndCinAsync(int testId, string cin, string result, string batchId, string referenceCode, int userId);
        Task ManageReflexTests(List<TestsModel> reflexTests, string cin, int loggedInUserId);
        Task<bool> ManageRequestedTestsDataAsync(List<TestsModel> testsToInsert, List<TestsModel> testsToRemove, string cin, int loggedInUserId);
        Task<SampleAndResultStatusAndResultModel> RejectTestByResultId(int resultId, string cin, int commentListId, int userId);
    }
}