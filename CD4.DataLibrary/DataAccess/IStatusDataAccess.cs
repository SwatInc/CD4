using CD4.DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IStatusDataAccess
    {
        Task<int> DetermineSampleStatus(int resultId);
        Task<List<StatusModel>> GetAllStatus();
        int GetRegisteredStatusId();
        Task<int> GetTestStatusByTestIdAndCin(int testId, string cin);
        int GetToValidateStatusId();
        Task<SampleAndResultStatusAndResultModel> MarkCollectedSampleAsAccepted(string cin, int loggedInUserId);
        Task<bool> MarkMultipleSamplesCollectedAsync(List<string> sampleCins, int loggedInUserId);
        Task<bool> MarkSampleCollectedAsync(string cin, int loggedInUserId);
        Task<StatusUpdatedSampleAndTestStatusModel> ValidateSample(string cin, int currentSampleStatus, int loggedInUserId);
        Task<bool> ValidateTest(string cin, string testDescription, int testStatus, string result, int loggedInUserId);
        Task SetSampleAcceptedTimeReceivedFromBilling(string cin, string acceptedAt);
    }
}