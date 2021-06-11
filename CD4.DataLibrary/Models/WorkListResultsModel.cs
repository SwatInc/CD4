namespace CD4.DataLibrary.Models
{
    public class WorkListResultsModel
    {
        public int Id { get; set; }
        public int AnalysisRequestId { get; set; }
        public string Cin { get; set; }
        public string Test { get; set; }
        public int StatusIconId { get; set; }
        public string Result { get; set; }
        public string DataType { get; set; }
        public string Mask { get; set; }
        public string Unit { get; set; }
        public string ReferenceCode { get; set; }
        public bool IsDeltaOk { get; set; }
        public int SortOrder { get; set; }
    }
}
