using System.Collections.Generic;

namespace CD4.DataLibrary.Models
{
    public class CompleteRequestSearchResultsModel
    {
        public RequestSearchDataModel RequestPatientSampleData { get; set; }
        public List<ClinicalDetailIdsModel> ClinicalDetailIds { get; set; }
        public List<ResultsDatabaseModel> RequestedTestsData { get; set; }

    }
}
