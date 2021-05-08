using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;

namespace CD4.BillingInterface.GrpcService.Services
{
    public interface IBillingCD4TestMapService
    {
        List<BillingTestMappingModel> GetTestMap();
    }
}