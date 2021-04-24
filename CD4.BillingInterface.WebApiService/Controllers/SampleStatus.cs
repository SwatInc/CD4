using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CD4.BillingInterface.WebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleStatus : ControllerBase
    {

        // GET api/<SampleStatus>/5
        [HttpGet("{id}")]
        public string Get(string sampleId)
        {
            return "value";
        }
    }
}
