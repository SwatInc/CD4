using CD4.DataLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class DataAccessBase
    {
        internal readonly SqlDataAccessHelper helper;

        public DataAccessBase()
        {
            this.helper = new SqlDataAccessHelper();
        }
    }
}
