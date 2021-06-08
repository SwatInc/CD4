using CD4.UI.Library.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public interface IHmsLinkViewModel
    {
        BindingList<HmsLinkDataModel> AnalysisRequests { get; set; }
        BindingList<PatientModel> Patient { get; set; }
        bool IsRequestPriority { get; set; }
        bool LoadingStaticDataStatus { get; set; }
        bool NotLoadingStaticData { get; set; }

        Task<bool> ConfirmAnalysisRequest(List<HmsLinkDataModel> dataToConfirm, int loggedInUserId);
        Task FetchAnalysisRequestForMemoNumberAsync(int memoNumber);
        Task<List<BarcodeDataModel>> GetBarcodeDataAsync();
        Task MaskEpisodeSamplesAsCollected(int LoggedInUserId);
        void ResetUi();
    }
}