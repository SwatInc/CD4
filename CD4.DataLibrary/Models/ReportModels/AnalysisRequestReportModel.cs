using System;
using System.Collections.Generic;

namespace CD4.DataLibrary.Models.ReportModels
{
    public class AnalysisRequestReportModel
    {
        public AnalysisRequestReportModel()
        {
            Assays = new List<AssaysModel>();
        }
        public string SampleSite { get; set; }
        public DateTimeOffset? CollectedDate { get; set; }
        public DateTimeOffset? ReceivedDate { get; set; }
        public string EpisodeNumber { get; set; }
        public PatientModel Patient { get; set; }
        public List<AssaysModel> Assays { get; set; }

    }
}
