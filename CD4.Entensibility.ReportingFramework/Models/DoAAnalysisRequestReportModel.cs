using System;
using System.Collections.Generic;
using System.Text;

namespace CD4.Entensibility.ReportingFramework.Models
{
    public class DoAAnalysisRequestReportModel
    {
        public string SampleSite { get; set; }
        public DateTimeOffset? CollectedDate { get; set; }
        public DateTimeOffset? ReceivedDate { get; set; }
        public string PrintedDate { get; set; }
        public Patient Patient { get; set; }
        public string EpisodeNumber { get; set; }
        public string QcCalValidatedBy { get; set; }
        public DateTimeOffset? ReportedAt { get; set; }
        public string ReceivedBy { get; set; }
        public string AnalysedBy { get; set; }
        public long InstituteAssignedPatientId { get; set; }
        public DateTimeOffset? SampleProcessedAt { get; set; }
        public string Opiates { get; set; }
        public string Benzodiazepine1 { get; set; }
        public string Benzodiazepine2 { get; set; }
        public string Benzodiazepines { get; set; }
        public string Cocaine { get; set; }
        public string Cannabinoids { get; set; }
        public string Amphetamine { get; set; }
        public string Ethanol { get; set; }
        public string Ethylglucuronide { get; set; }
        public string Methadone { get; set; }

    }
}
