using CD4.DataLibrary.Models;
using System.Collections.Generic;

namespace CD4.BillingInterface.WebApiService.Services
{
    public interface IBillingCD4AnalysesMapService
    {
        List<BillingTestMappingModel> GetTestMap();
    }
}