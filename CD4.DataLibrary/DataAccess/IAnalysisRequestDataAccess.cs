using CD4.DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IAnalysisRequestDataAccess
    {
        Task<bool> ConfirmRequestAsync(AnalysisRequestDataModel request);
        Task<List<BarcodeDataModel>> GetBarcodeDataAsync(string cin);
        Task<int> GetNextCinSeed();
        Task<CompleteRequestSearchResultsModel> SearchRequestByCinAsync(string cin = "nCoV-4654/20");
    }
}