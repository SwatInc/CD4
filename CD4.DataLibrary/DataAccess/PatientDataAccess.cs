using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<PatientNidPpAndNameModel> GetPatientBySamplCin(string cin)
        {
            var storedProcedure = "[dbo].[usp_GetPatientIdFullnameByCin]";
            var parameter = new { Cin = cin };
            try
            {
                var results = await LoadDataWithParameterAsync<PatientNidPpAndNameModel, dynamic>
                    (storedProcedure, parameter);
                return results.FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Inserts a patient to the database.
        /// </summary>
        /// <param name="patient"></param>
        /// <returns>An integer representing inserted patient Id</returns>
        public async Task<int> InsertPatient(PatientInsertDatabaseModel patient)
        {
            var storedProcedure = "[dbo].[usp_InsertPatient]";
            return await SelectInsertOrUpdateAsync<int, PatientInsertDatabaseModel>
                (storedProcedure, patient);
        }

        public async Task<bool> UpdatePatientById(PatientUpdateDatabaseModel patient)
        {
            try
            {
                var storedProcedure = "[dbo].[usp_UpdatePatientWithId]";
                _ = await SelectInsertOrUpdateAsync<dynamic, PatientUpdateDatabaseModel>
                    (storedProcedure, patient);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PatientUpdateDatabaseModel> UpdatePatientByIdReturnInserted(PatientUpdateDatabaseModel patient)
        {
            try
            {
                var storedProcedure = "[dbo].[usp_UpdatePatientWithId]";
                return await SelectInsertOrUpdateAsync<PatientUpdateDatabaseModel, PatientUpdateDatabaseModel>
                    (storedProcedure, patient);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
