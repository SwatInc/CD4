using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public class RequestAndSampleDatabaseModel
    {
        public int RequestId { get; set; }
        public string EpisodeNumber { get; set; }
        public string Age { get; set; }
        public string Cin { get; set; }
        public int SiteId { get; set; }
        public DateTime CollectionDate { get; set; }
        public DateTime ReceivedDate { get; set; }

        public bool AreEqual(AnalysisRequestDataModel request)
        {
            if (Age != request.Age) return false;
            if (Cin != request.Cin) return false;
            if (SiteId != request.SiteId) return false;
            if (CollectionDate.ToString("yyyMMdd") != request.SampleCollectionDate.ToString("yyyMMdd")) return false;
            if (ReceivedDate.ToString("yyyMMdd") != request.SampleReceivedDate.ToString("yyyMMdd")) return false;
            if (EpisodeNumber != request.EpisodeNumber) return false;
            return true;
        }
    }
}
