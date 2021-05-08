using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CD4.BillingInterface.WebApiService.Models
{
    public class SampleStatusModel
    {
        public Response Response { get; set; }
        public string SampleId { get; set; }
        public string Status { get; set; }
    }
}
