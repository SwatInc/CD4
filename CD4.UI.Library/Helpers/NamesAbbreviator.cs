using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.Helpers
{
    public static class NamesAbbreviator
    {
        public static string Execute(string fullname, int maxLength)
        {
            string abbreviatedFullname = "";
            //check whether abbreviation is necessary
            if (fullname.Length < maxLength) return fullname;

            var names = fullname.Split(' ');

            //two names in fullname and length graterthan max length
            if (names.Length == 2 && fullname.Length >= maxLength)
            {
                //abbreviate 1st name segment
                var name = $"{names[0].Substring(0, 1)}.";
                abbreviatedFullname =  $"{name} {names[1]}";
            }

            //Not abbreviating first and last name
            for (int i = 1; i < names.Length-1; i++)
            {
                //abbreviate the name segment
                var name = $"{names[i].Substring(0, 1)}.";
                names[i] = name;
                //assemble the name
                abbreviatedFullname = AssembleName(names);
                //check the length 
                if (fullname.Length < maxLength) break;
            }

            return abbreviatedFullname.Trim();
        }

        private static string AssembleName(string[] names)
        {
            var assembledName = "";
            foreach (var name in names)
            {
                assembledName = $"{assembledName} {name}";
            }

            return assembledName;
        }
    }
}
