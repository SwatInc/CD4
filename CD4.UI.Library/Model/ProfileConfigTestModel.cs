using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.Model
{
    public class ProfileConfigTestModel
    {
        public int Id { get; set; }
        public string TestDescription { get; set; }

        public override string ToString()
        {
            return this.TestDescription;
        }
    }
}
