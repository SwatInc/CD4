﻿using CD4.DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IPatientDataAccess
    {
        Task<List<PatientModel>> GetPatientByNidPp(string NidPp);
        Task<List<PatientModel>> GetPatientByPartialName(string partialName);
        Task<PatientNidPpAndNameModel> GetPatientBySamplCin(string cin);
        Task<int> InsertPatient(PatientInsertDatabaseModel patient);
        Task<bool> UpdatePatientById(PatientUpdateDatabaseModel patient);
        Task<PatientUpdateDatabaseModel> UpdatePatientByIdReturnInserted(PatientUpdateDatabaseModel patient);
    }
}