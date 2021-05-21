namespace CD4.DataLibrary.Models.ReportModels
{
    public class AssaysModel
    {
        public string Cin { get; set; }
        public string Discipline { get; set; }
        public string Assay { get; set; }
        public string Result { get; set; }
        public string Unit { get; set; }
        public string DisplayNormalRange { get; set; } //this is age, gender and test specific
        public string Comment { get; set; }
    }
}
