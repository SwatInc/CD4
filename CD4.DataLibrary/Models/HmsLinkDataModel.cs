using System;


namespace CD4.DataLibrary.Models
{
    public class HmsLinkDataModel
    {
        public int EpisodeNumber { get; set; }
        public string PatientId { get; set; }
        public string NidPp { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int RegAtollId { get; set; }
        public int RegIslandId { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Address { get; set; }
        public DateTime? BillDate { get; set; }

        public int BillItemDetailEntryId { get; set; }
        public int ItemCode { get; set; }
        public string ItemDescription { get; set; }
    }
}