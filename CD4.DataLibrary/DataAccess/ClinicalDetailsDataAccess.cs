using CD4.DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class ClinicalDetailsDataAccess : DataAccessBase
    {
        public async Task<List<ClinicalDetailsDatabaseModel>> GetClinicalDetailsByRequestId(int requestId)
        {
            var storedProcedure = "";
            return await LoadDataAsync<ClinicalDetailsDatabaseModel>(storedProcedure);
        }
    }
}
