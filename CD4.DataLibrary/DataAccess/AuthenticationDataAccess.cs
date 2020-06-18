using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class AuthenticationDataAccess : DataAccessBase, IAuthenticationDataAccess
    {
        public async Task<AuthorizeDetailModel> Authenticate
            (string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
