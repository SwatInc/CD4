using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class StatusDataAccess : DataAccessBase, IStatusDataAccess
    {
        /// <summary>
        /// Fetches statusId for the specified status string from the database
        /// </summary>
        /// <param name="status">The status for which the Id is to be queried.</param>
        /// <returns>integer representing Status Id for the specified status</returns>
        public async Task<int> GetStatusIdByStatus(string status)
        {
            //the stored procedure name to call
            var storedProcedure = "usp_GetStatusIdByStatus";
            //set up the status name parameter
            var parameter = new { Status = status };

            //call the base class to execute the stored procedure.
            var output = await SelectInsertOrUpdate<int, dynamic>(storedProcedure, parameter);
            return output;
        }
    }
}
