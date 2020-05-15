using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    /// <summary>
    /// This model is primarily intended used to check which tests are
    /// requested for the sample / request.
    /// </summary>
    public class ResultsDatabaseModel
    {
        public int Id { get; set; }
        public int AnalysisRequestId { get; set; }
        public string Sample_Cin { get; set; }
        public int TestId { get; set; }
        public string Result { get; set; }
        public DateTime ResultDate { get; set; }
    }
}
