using System.Collections.Generic;
using System.Diagnostics;

namespace CD4.DataLibrary.Models
{
    public class WorklistModel
    {
        public List<WorklistPatientDataModel> PatientData { get; set; }
        public List<WorkListResultsModel> TestResultsData { get; set; }
    }
}