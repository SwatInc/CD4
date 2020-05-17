using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public class AnalysisRequestInsertDatabaseModel
    {
        public int PatientId { get; set; }
        public string EpisodeNumber { get; set; }
        public string Age { get; set; }

    }
}
