using System.Collections.Generic;

namespace CD4.DataLibrary.Models
{
    public class SampleAndResultStatusAndResultModel
    {
        public StatusUpdatedSampleModel SampleData { get; set; }
        public List<UpdatedResultAndStatusModel> ResultStatus { get; set; }
    }
}
