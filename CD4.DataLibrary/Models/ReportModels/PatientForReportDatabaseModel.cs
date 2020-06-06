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
        public string SampleSite { get; set; }
        public DateTime CollectedDate { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string Cin { get; set; }
    }
}
