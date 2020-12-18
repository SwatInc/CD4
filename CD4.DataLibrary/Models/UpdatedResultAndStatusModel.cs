using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public class UpdatedResultAndStatusModel
    {
        public int ResultId { get; set; }
        public string Cin { get; set; }
        public string Result { get; set; }
        public string ReferenceCode { get; set; }
        public int StatusId { get; set; }
        public string TestName { get; set; }
        public string Unit { get; set; }

    }
}
