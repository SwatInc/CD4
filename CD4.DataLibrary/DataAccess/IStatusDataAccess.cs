using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IStatusDataAccess
    {
        Task<int> GetStatusIdByStatus(string status);
    }
}