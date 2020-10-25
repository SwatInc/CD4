using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public class ResultHistoryModel
    {
        public int Id { get; set; }
        public string Result { get; set; }
        public DateTimeOffset ResultDate { get; set; }
    }
}
