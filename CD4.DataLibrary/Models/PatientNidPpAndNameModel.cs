using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public class PatientNidPpAndNameModel
    {
        public string NidPp { get; set; }
        public string Fullname { get; set; }

        public bool IsMatch(AnalysisRequestDataModel request)
        {
            if (NidPp != request.NationalIdPassport)
            {
                return false;
            }
            return true;
        }
    }
}
