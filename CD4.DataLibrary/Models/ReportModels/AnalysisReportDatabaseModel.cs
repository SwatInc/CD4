using System.Collections.Generic;

namespace CD4.DataLibrary.Models.ReportModels
{
    public class AnalysisReportDatabaseModel
    {
        public AnalysisReportDatabaseModel()
        {
            Results = new List<ResultsForAnalysisReportDatabaseModel>();
        }
        public PatientForAnalysisReportDatabaseModel Patient { get; set; }
        public List<ResultsForAnalysisReportDatabaseModel> Results { get; set; }
    }
}
