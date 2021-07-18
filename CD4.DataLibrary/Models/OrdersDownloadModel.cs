using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public class OrdersDownloadModel
    {
        public string Download { get; set; }
        public string Sid { get; set; }
        public bool SamplePriority { get; set; }
        public bool TestPriority { get; set; }
        public string EpisodeNumber { get; set; }
        public string Age { get; set; }
        public string Fullname { get; set; }
        public string NidPp { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }

    }
}
