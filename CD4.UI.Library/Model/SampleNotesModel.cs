using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.Model
{
    public class SampleNotesModel
    {
        public string CIN { get; set; }
        public string Note { get; set; }
        public bool IsAttended { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

    }
}
