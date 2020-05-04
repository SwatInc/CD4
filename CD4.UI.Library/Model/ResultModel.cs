using System;

namespace CD4.UI.Library.Model
{
    public class ResultModel
    {
        public int Id { get; set; }
        public int AnalysisRequestId { get; set; }
        public string Cin { get; set; }
        public string Test { get; set; }
        public string Result { get; set; }
        public DateTime ResultDate { get; set; }
        public string DataType { get; set; }
    }
}
