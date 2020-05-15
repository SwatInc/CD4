using CD4.DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class ClinicalDetailsDataAccess : DataAccessBase, IClinicalDetailsDataAccess
    {
        public async Task<List<ClinicalDetailsDatabaseModel>> GetClinicalDetailsByRequestId(int requestId)
        {
            var parameter = new RequestIdParameterModel() { AnalysisRequestId = requestId };
            var storedProcedure = "[dbo].[usp_GetClinicalDetailsByRequestId]";
            return await LoadDataWithParameterAsync<ClinicalDetailsDatabaseModel, RequestIdParameterModel>(storedProcedure,parameter);
        }
    }
}
