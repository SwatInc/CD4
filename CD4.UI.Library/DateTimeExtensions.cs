using System;

namespace CD4.UI.Library
{
    public static class DateTimeExtensions
    {
        //Refactored.
        //https://stackoverflow.com/questions/3054715/c-sharp-calculate-accurate-age
        public static string ToAgeString(this DateTime dob)
        {
            var today = DateTime.Today;
            var months = today.Month - dob.Month;
            var years = today.Year - dob.Year;

            if (today.Day < dob.Day) { months--; }
            if (months < 0) { years--; months += 12; }
            var days = (today - dob.AddMonths((years * 12) + months)).Days;

            return string.Format("{0} Y, {1} M, {2} D",
                                 years,
                                 months,
                                 days);
        }
    }
}
