using CD4.DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IPatientDataAccess
    {
        Task<List<PatientModel>> GetPatientByNidPp(string NidPp);
        Task<List<PatientModel>> GetPatientByPartialName(string partialName);
        Task<int> InsertPatient(PatientInsertDatabaseModel patient);
        Task<bool> UpdatePatient(PatientUpdateDatabaseModel patient);
    }
}