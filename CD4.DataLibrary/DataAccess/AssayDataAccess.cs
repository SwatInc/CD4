using CD4.DataLibrary.Models;
using System;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    /// <summary>
    /// Creats, reads and updates records for dbo.Test
    /// This class is named AssayDataAccess instead of TestDataAccess to avoid possible confusion of the word test
    /// </summary>
    public class AssayDataAccess : DataAccessBase, IAssayDataAccess
    {
        public async Task<TestsModel> GetAllAssays()
        {
            throw new NotImplementedException();
        }
    }
}
