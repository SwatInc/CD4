using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.Model
{
    public class SampleWithTestsModel
    {
        public SampleWithTestsModel()
        {
            Tests = new List<TestModel>();
        }
        public string Cin { get; set; }
        public List<TestModel> Tests { get; set; }
    }
}
