using CD4.UI.Library.Model;
using System;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public interface IAuthenticationViewModel
    {
        event EventHandler<AuthorizeDetailEventArgs> AuthenticationStatusIndication;
        string Password { get; set; }
        string Username { get; set; }
        bool CanLogIn { get; set; }

        Task AuthenticateUser();
    }
}