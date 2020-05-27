namespace CD4.DataLibrary.Models
{
    public class ExistingRequestsPatientComparisionArgs
    {
        public PatientNidPpAndNameModel DatabasePatient { get; set; }
        public bool IsAnalysisRequestsPatientChanged { get; set; }
    }
}
