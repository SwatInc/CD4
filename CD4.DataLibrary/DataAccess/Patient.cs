using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class Patient: DataAccessBase
    {
        public async Task<List<PatientModel>> GetPatientByPartialName(string partialName)
        {
            var storedProcedure = "[dbo].[usp_SearchPatientByPartialName]";
            var parameter = new PatientNameSearchModel() { PartialPatientName = partialName };
            try
            {
                var results =  await LoadDataWithParameterAsync<PatientModel,PatientNameSearchModel>
                    (storedProcedure, parameter);
                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
