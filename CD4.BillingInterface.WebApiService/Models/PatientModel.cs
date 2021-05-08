using System;

namespace CD4.BillingInterface.WebApiService.Models
{
    public class PatientModel
    {
        public string NidPp { get; set; }
        public string PatientId { get; set; }
        public string Fullname { get; set; }
        public int GenderId { get; set; }
        public long Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public string Age { get; set; }
        public int NationalityId { get; set; }
        public string Address { get; set; }
        public int AtollId { get; set; }
    }

}
