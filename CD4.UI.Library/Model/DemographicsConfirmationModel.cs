using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.Model
{
    public class DemographicsConfirmationModel
    {
        public PatientModel Patient { get; set; }
        public bool IsConfirmationRequired { get; set; }
        public string Age { get; set; }
    }
}
