namespace CD4.DataLibrary.Models
{
    public class AnalysisRequestUpdateDatabaseModel
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string EpisodeNumber { get; set; }
        public string Age { get; set; }

    }
}
