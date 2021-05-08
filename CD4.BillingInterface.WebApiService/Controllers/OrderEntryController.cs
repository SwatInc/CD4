using CD4.BillingInterface.WebApiService.Models;
using CD4.BillingInterface.WebApiService.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CD4.BillingInterface.WebApiService.Controllers
{
    [Route("api/orderentry")]
    [ApiController]
    public class OrderEntryController : ControllerBase
    {
        private readonly IAnalysisRequestService _analysisRequestService;

        public OrderEntryController(IAnalysisRequestService analysisRequestService)
        {
            _analysisRequestService = analysisRequestService;
        }

        // POST api/<OrderEntry>
        [HttpPost]
        public async Task<Response> Post([FromBody] AnalysisRequestModel analysisRequest)
        {
            try
            {
                return await _analysisRequestService.Save(analysisRequest);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
