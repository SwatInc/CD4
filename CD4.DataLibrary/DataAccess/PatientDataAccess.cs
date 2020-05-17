using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class PatientDataAccess : DataAccessBase, IPatientDataAccess
    {
        public async Task<List<PatientModel>> GetPatientByPartialName(string partialName)
        {
            var storedProcedure = "[dbo].[usp_SearchPatientByPartialName]";
            var parameter = new PatientNameParameterModel() { PartialPatientName = partialName };
            try
            {
                var results = await LoadDataWithParameterAsync<PatientModel, PatientNameParameterModel>
                    (storedProcedure, parameter);
                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<PatientModel>> GetPatientByNidPp(string NidPp)
        {
            var storedProcedure = "[dbo].[usp_SearchPatientByNidPp]";
            var parameter = new NidPpParameterModel() { NidPp = NidPp };
            try
            {
                var results = await LoadDataWithParameterAsync<PatientModel, NidPpParameterModel>
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
