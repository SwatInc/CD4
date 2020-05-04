using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library
{
    public class DiskIO
    {
        public static string ReadValidationData()
        {
            return File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}\\RegexValidationData.json");
        }

    }

}
