using System;

namespace CD4.DataLibrary.Models
{
    public class WorklistPatientDataModel
    {
        public int AnalysisRequestId { get; set; }
        public string Cin { get; set; }
        public DateTime? CollectionDate { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string FullName { get; set; }
        public string NidPp { get; set; }
        public string AgeSex { get; set; }
        public DateTime? Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string AtollIslandCountry { get; set; }
        public string EpisodeNumber { get; set; }
        public string Site { get; set; }
        public string CsvClinicalDetails { get; set; }

    }
}