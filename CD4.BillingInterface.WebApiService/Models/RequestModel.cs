using System;
using System.Linq;
using System.Threading.Tasks;

namespace CD4.BillingInterface.WebApiService.Models
{
    public class RequestModel
    {
        public string MemoNumber { get; set; }
        public string SampleId { get; set; }
        public int SiteId { get; set; }
        public int SampleReceivedBy { get; set; }
        public long SampleCollectedAt { get; set; }
        public long SampleReceivedAt { get; set; }
    }
}
