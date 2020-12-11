using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.Model
{
    public class ResultAlertModel
    {
        public string TestName { get; set; }
        public string Result { get; set; }
        public string ResultType { get; set; }
        public string AlertMessage { get; set; }
        public string Operator { get; set; }
    }
}
