using CD4.DataLibrary.Models;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IAuthenticationDataAccess
    {
        Task<AuthorizeDetailModel> Authenticate(string username, string password);
        Task ChangePassword(string currentPassword, string username, string newPassword);
    }
}