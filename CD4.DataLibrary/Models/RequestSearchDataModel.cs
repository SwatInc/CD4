using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public class RequestSearchDataModel
    {
        public string Cin { get; set; }
        public string EpisodeNumber { get; set; }
        public int SiteId { get; set; }
        public DateTimeOffset? CollectionDate { get; set; }
        public DateTimeOffset? ReceivedDate { get; set; }
        public string NidPp { get; set; }
        public string Fullname { get; set; }
        public int GenderId { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Address { get; set; }
        public string Atoll { get; set; }
        public string Island { get; set; }
        public int CountryId { get; set; }
        public long  InstituteAssignedPatientId { get; set; }
        public bool SamplePriority { get; set; }
    }
}
