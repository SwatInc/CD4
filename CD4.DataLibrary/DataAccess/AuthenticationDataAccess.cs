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
            //get username and password hash from database.
            var storedProcedure = "[dbo].[usp_GetHashForUsername]";
            var parameter = new { username = username };

            var result = await SelectInsertOrUpdate<UsernameAndHashModel, dynamic>
                (storedProcedure,parameter);
            //if username is not found, return isAuthentcated as false.
            if (result is null)
            { return new AuthorizeDetailModel() { IsAuthenticated = false };}
            //Hash the password and compare with returned hash
            //if hash match returns true, fetch other details for return model.
            //return
            throw new NotImplementedException();
        }
    }
}
