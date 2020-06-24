using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IStatusDataAccess
    {
        int GetRegisteredStatusId();
        int GetToValidateStatusId();
    }
}