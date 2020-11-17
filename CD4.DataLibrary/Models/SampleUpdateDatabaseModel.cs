using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public class SampleUpdateDatabaseModel
    {
        public string Cin { get; set; }
        public int SiteId { get; set; }
        public DateTimeOffset? CollectionDate { get; set; }
        public DateTimeOffset? ReceivedDate { get; set; }
        public int UserId { get; set; }
    }
}
