﻿using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Inserts a patient to the database.
        /// </summary>
        /// <param name="patient"></param>
        /// <returns>An integer representing inserted patient Id</returns>
        public async Task<int> InsertPatient(PatientInsertDatabaseModel patient)
        {
            var storedProcedure = "[dbo].[usp_InsertPatient]";
            return await InsertOrUpdate<int, PatientInsertDatabaseModel>
                (storedProcedure, patient);
        }

        public async Task<bool> UpdatePatient(PatientUpdateDatabaseModel patient)
        {
            try
            {
                var storedProcedure = "[dbo].[usp_UpdatePatientWithId]";
                _ = await InsertOrUpdate<bool, PatientUpdateDatabaseModel>
                    (storedProcedure, patient);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
