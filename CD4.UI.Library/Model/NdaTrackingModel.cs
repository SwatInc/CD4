using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.Model
{
    public class NdaTrackingModel
    {
        public long InstituteAssignedPatientId { get; set; }
        public string Cin { get; set; }
        public Image Status { get; set; }
        public string TestedBy { get; set; }
        public string CalQcValidatedBy { get; set; }
        public DateTimeOffset? CollectedDate { get; set; }
        public DateTimeOffset? ReceivedDate { get; set; }
        public DateTimeOffset? ProcessedDate { get; set; }
        public DateTimeOffset? ValidatedDateTime { get; set; }
        public DateTimeOffset? ReportedDate { get; set; }
    }
}
