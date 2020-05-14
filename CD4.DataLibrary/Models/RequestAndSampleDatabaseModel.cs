using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public class RequestAndSampleDatabaseModel
    {
        public int RequestId { get; set; }
        public string Age { get; set; }
        public string Cin { get; set; }
        public int SiteId { get; set; }
        public DateTime CollectionDate { get; set; }
        public DateTime ReceivedDate { get; set; }
    }
}
