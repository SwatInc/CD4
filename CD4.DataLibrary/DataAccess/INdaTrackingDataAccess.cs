using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface INdaTrackingDataAccess
    {
        Task<List<NdaTrackingModel>> LoadSearchResults(DateTime fromDate, DateTime toDate, int sampleStatus);
        Task<List<CinAndFullnameModel>> UpsertAnalysedUserAsync(List<string> cins, int loggedInUserId, int actionUserId);
        Task<List<CinAndFullnameModel>> UpsertQcCalValidatedUserAsync(List<string> cins, int loggedInUserId, int actionUserId);
        Task<List<CinAndReportDateModel>> UpsertReportDateAsync(List<string> cins, DateTime reportDate, int loggedInUserId);
        Task UpsertSampleReceivedUserIdAsync(string cin, int sampleReceivedUserId, int loggedInUser);
    }
}