using CD4.BillingInterface.WebApiService.Models;
using System.Threading.Tasks;

namespace CD4.BillingInterface.WebApiService.Services
{
    public interface IAnalysisRequestService
    {
        Task<Response> Save(AnalysisRequestModel request);
    }
}