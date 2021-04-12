using System;

namespace CD4.Entensibility.ReportingFramework.Models
{
    public class Patient
    {
        public string NidPp { get; set; }
        public string Fullname { get; set; }
        public string AgeSex { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public long InstituteAssignedPatientId { get; set; }

    }
}