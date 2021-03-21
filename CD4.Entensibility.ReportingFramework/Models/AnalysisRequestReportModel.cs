using Newtonsoft.Json;
using System;
using System.ComponentModel;

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

        public string Pdf417String { get; private set; }

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
        }
    }
}
