using System.Data;
using System.Data.SqlClient;

namespace CD4.DataLibrary.DataAccess
{
    public class AnalysisRequest : DataAccessBase, IAnalysisRequest
    {
        public void Save()
        {
            using (IDbConnection connection = new SqlConnection(helper.GetConnectionString()))
            {
                //Query
            }
        }
    }
}
