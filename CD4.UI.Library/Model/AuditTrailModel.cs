using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.Model
{
    public class AuditTrailModel
    {
        public DateTimeOffset CreatedAt { get; set; }
        public string Details { get; set; }
        public string Cin { get; set; }
    }
}
