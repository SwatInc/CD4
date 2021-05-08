using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CD4.BillingInterface.WebApiService.Models
{
    public class AnalysisRequestModel
    {
        public RequestModel Request { get; set; }
        public PatientModel Patient { get; set; }
        public  AnalysisModel Analyses { get; set; }
    }
}
