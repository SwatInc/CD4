using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Helpers
{
    public class DateHelper
    {
        public static string GetCD4FormatDate(DateTime? nullabledate)
        {
            if (nullabledate is null)
            {
                return null;
            }
            return ((DateTime)nullabledate).ToString("yyyyMMdd");
        }
    }
}
