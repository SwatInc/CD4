using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public class ClinicalDetailsDatabaseModel
    {
        public int Id { get; set; }
        public int AnalysisRequestId { get; set; }
        public int ClinicalDetailsId { get; set; }
    }

}
