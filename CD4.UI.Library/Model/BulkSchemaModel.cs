using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.Model
{
    public class BulkSchemaModel
    {
        private string fullname;
        private string nidPp;
        private string gender;
        private string nationality;

        public string NidPp
        {
            get => nidPp; set
            {
                nidPp = value.Trim();
            }
        }
        public string Fullname
        {
            get => fullname; set
            {
                fullname = value.Trim().ToUpper();
            }
        }
        public string Gender
        {
            get => gender; set
            {
                gender = value.Trim().ToUpper();
            }
        }
        public DateTime Birthdate { get; set; }
        public int PhoneNumber { get; set; }
        public string Nationality
        {
            get => nationality; set
            {
                nationality = value.Trim().ToUpper();
            }
        }
        public bool BreathingDifficulty { get; set; }
        public bool Cough { get; set; }
        public bool Fever { get; set; }
        public bool TravelHistory { get; set; }
        public DateTime SampleCollectedDateTime { get; set; }

    }
}
