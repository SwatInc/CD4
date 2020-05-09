using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public class ProfileTestsDatabaseModel
    {
        public int ProfileId { get; set; }
        public int  TestId { get; set; }
        public string Test { get; set; }
        public string Mask { get; set; }
        public bool IsReportable { get; set; }
        public string ResultDataType { get; set; }
    }
}
