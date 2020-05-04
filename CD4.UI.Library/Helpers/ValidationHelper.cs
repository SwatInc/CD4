using CD4.UI.Library.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CD4.UI.Library.Helpers
{
    public static class ValidationHelper
    {
        private static List<ValidationDataModel> validationData =
            JsonConvert.DeserializeObject<List<ValidationDataModel>>(DiskIO.ReadValidationData());

        public static Regex Cin = new Regex(validationData.Find(v => v.Tag == "CIN").Regex, RegexOptions.Compiled);

        public static string GetInvalidMessage(string tag)
        {
            return validationData.Find(v => v.Tag == tag).InValidMessage;
        }

    }
}
