using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.ResultsInterface.Models
{
    public class ChannelMappingModel
    {
        public int TestId { get; set; }
        public string Download { get; set; }
        public string Upload { get; set; }
        public string Unit { get; set; }
        public string AnalyserName { get; set; }
        public string Mask { get; set; }
        public string DataType { get; set; }
    }
}
