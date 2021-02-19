using CD4.DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IAnalysisRequestDataAccess
    {
        Task<bool> ConfirmRequestAsync(AnalysisRequestDataModel request, int loggedInUserId);
        Task<List<BarcodeDataModel>> GetBarcodeDataAsync(string cin);
        Task<List<BarcodeDataModel>> GetBarcodeDataForMultipleSamplesAsync(List<string> sampleCins);
        Task<string> GetNextCinSeed();
        Task<CompleteRequestSearchResultsModel> SearchRequestByCinAsync(string cin);
    }
}