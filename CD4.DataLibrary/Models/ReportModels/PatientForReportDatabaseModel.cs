using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models.ReportModels
{
    public class PatientForAnalysisReportDatabaseModel
    {
        public string NidPp { get; set; }
        public string Fullname { get; set; }
        public string AgeSex { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public string SampleSite { get; set; }
        public DateTimeOffset? CollectedDate { get; set; }
        public DateTimeOffset? ReceivedDate { get; set; }
        public string Cin { get; set; }
        public int StatusIconId { get; set; }
        public string EpisodeNumber { get; set; }
        public string QcCalValidatedBy { get; set; }
        public DateTimeOffset? ReportedAt { get; set; }
        public string ReceivedBy { get; set; }
        public string ReportedBy { get; set; }
        public long InstituteAssignedPatientId { get; set; }

    }
}
