using CD4.DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IAnalysisRequestDataAccess
    {
        Task<bool> ConfirmRequestAsync(AnalysisRequestDataModel request, int loggedInUserId, bool isSamplePriority = false);
        Task<List<BarcodeDataModel>> GetBarcodeDataAsync(string cin);
        Task<List<BarcodeDataModel>> GetBarcodeDataForMultipleSamplesAsync(List<string> sampleCins);
        Task<List<BarcodeDataModel>> GetBarcodeDataForMultipleSamplesAsync(string episodeNumber);
        Task<string> GetNextCinSeed();
        Task<string> GetNextCinSeedWithoutPrefix();
        Task<CompleteRequestSearchResultsModel> SearchRequestByCinAsync(string cin);
    }
}