using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CD4.UI
{
    public interface IFormFactory
    {
        Form CreateForm(Type formType);
    }
}
