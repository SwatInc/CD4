using System.Collections.Generic;

namespace CD4.BillingInterface.WebApiService.Models
{
    public class AnalysisModel
    {
        public AnalysisModel()
        {
            RequestedTests = new List<string>();
        }
        public List<string> RequestedTests { get; set; }
    }
}
