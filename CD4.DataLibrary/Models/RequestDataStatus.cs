using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public enum RequestDataStatus
    {
        New, //new record, cannot find a match on database
        Dirty, //Dirty record. Does not match with that of database
        Clean //Matches with the record from database
    }
}
