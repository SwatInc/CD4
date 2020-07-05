using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public enum Status
    {
        Registered = 1,
        Collected,
        Received,
        ToValidate,
        Validated,
        Processing,
        Rejected
    }
}
