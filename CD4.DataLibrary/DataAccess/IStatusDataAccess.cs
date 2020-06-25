using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IStatusDataAccess
    {
        Task<int> DetermineSampleStatus(int resultId);
        int GetRegisteredStatusId();
        int GetToValidateStatusId();
    }
}