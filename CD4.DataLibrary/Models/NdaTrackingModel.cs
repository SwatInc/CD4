using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public class NdaTrackingModel
    {
        public string MemoNumber { get; set; }
        public long InstituteAssignedPatientId { get; set; }
        public string Cin { get; set; }
        public int StatusIconId { get; set; }
        public string AnalysedBy { get; set; }
        public string CalQcValidatedBy { get; set; }
        public DateTimeOffset? CollectedDate { get; set; }
        public DateTimeOffset? ReceivedDate { get; set; }
        public DateTimeOffset? ValidatedDateTime { get; set; }
        public DateTimeOffset? ReportedDate { get; set; }
    }
}
