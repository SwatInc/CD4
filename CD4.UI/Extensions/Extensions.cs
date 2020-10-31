
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CD4.UI.Extensions
{
    public static class Extensions
    {
        public static IEnumerable<T> Descendants<T>(this Control control) where T : class
        {
            foreach (Control child in control.Controls)
            {

                T childOfT = child as T;
                if (childOfT != null)
                {
                    Debug.WriteLine(childOfT.ToString());
                    yield return (T)childOfT;
                }

                if (child.HasChildren)
                {
                    foreach (T descendant in Descendants<T>(child))
                    {
                        Debug.WriteLine(descendant.ToString());
                        yield return descendant;
                    }
                }
            }
        }

    }
}
