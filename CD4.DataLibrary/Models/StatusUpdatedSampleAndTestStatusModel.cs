using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public class StatusUpdatedSampleAndTestStatusModel
    {
        public StatusUpdatedSampleModel SampleStatus { get; set; }
        public List<StatusUpdatedTestModel> TestStatusList { get; set; }
    }
}
