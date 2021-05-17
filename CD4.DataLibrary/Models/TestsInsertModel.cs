using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public class TestsInsertModel
    {
        public int DisciplineId { get; set; }
        public string Description { get; set; }
        public int SampleTypeId { get; set; }
        public int ResultDataTypeId { get; set; }
        public string Mask { get; set; }
        public int UnitId { get; set; }
        public bool Reportable { get; set; }
        public string Code { get; set; }
        public bool DefaultCommented { get; set; }
    }
}
