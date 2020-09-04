using CD4.DataLibrary.Helpers;
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
        public DateTimeOffset? CollectionDate { get; set; }
        public DateTimeOffset? ReceivedDate { get; set; }

        public bool AreEqual(AnalysisRequestDataModel request)
        {
            if (Age != request.Age) return false;
            if (Cin != request.Cin) return false;
            if (SiteId != request.SiteId) return false;
            if (DateHelper.GetCD4FormatDate(CollectionDate) != DateHelper.GetCD4FormatDate(request.SampleCollectionDate)) return false;
            if (DateHelper.GetCD4FormatDate(ReceivedDate) != DateHelper.GetCD4FormatDate(request.SampleReceivedDate)) return false;
            if (EpisodeNumber != request.EpisodeNumber) return false;
            return true;
        }
    }
}
