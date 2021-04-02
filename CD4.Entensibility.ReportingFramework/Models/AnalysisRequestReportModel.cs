using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Text;

namespace CD4.Entensibility.ReportingFramework.Models
{
    public class AnalysisRequestReportModel
    {
        public string SampleSite { get; set; }
        public DateTimeOffset? CollectedDate { get; set; }
        public DateTimeOffset? ReceivedDate { get; set; }
        public string PrintedDate { get; set; }
        public Patient Patient { get; set; }
        public BindingList<Assays> Assays { get; set; }
        public string EpisodeNumber { get; set; }
        public string QcCalValidatedBy { get; set; }
        public DateTimeOffset? ReportedAt { get; set; }
        public string ReceivedBy { get; set; }
        public string AnalysedBy { get; set; }
        public long InstituteAssignedPatientId { get; set; }
        public string Pdf417String { get; private set; }
        public Byte[] Pdf417Binary { get; private set; }

        public void SetPdf417String()
        {
            Pdf417String = (JsonConvert.SerializeObject(this, Formatting.Indented))
                .Replace("\"", null)
                .Replace(",", null)
                .Replace("{", null)
                .Replace("}", null)
                .Replace("[", null)
                .Replace("[", null)
                .Replace("]", null)
                .Replace("Pdf417String: null", null)
                .Trim();

            Pdf417Binary = UTF8Encoding.UTF8.GetBytes($"{Patient.NidPp}|{Patient.Fullname}|{Assays[0].Cin}|{Assays[0].Result}");
        }
    }
}
