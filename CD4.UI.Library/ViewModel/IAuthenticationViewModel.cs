using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public interface IAuthenticationViewModel
    {
        string Password { get; set; }
        string Username { get; set; }
        bool CanLogIn { get; set; }

        Task AuthenticateUser();
    }
}