using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models.ReportModels
{
    public class PatientModel
    {
        public string NidPp { get; set; }
        public string Fullname { get; set; }
        public string AgeSex { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
    }
}
