using CD4.DataLibrary.Models;
using Newtonsoft.Json.Serialization;
using SwatIncCrypto;
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
            { 
                return new AuthorizeDetailModel() 
                {
                    IsAuthenticated = false,
                    Message = "Username or password is incorrect!"
                };
            }
            //if hash match returns true, fetch other details for return model.
            if (VerifyPassword(password, result.PasswordHash))
            {
                throw new NotImplementedException();
            }
            else
            {
                //return IsAuthenticated as flase with message.
                return new AuthorizeDetailModel()
                {
                    IsAuthenticated = false,
                    Message = "Username or password is incorrect!"
                };
            }
        }

        /// <summary>
        /// hashes the provided string password
        /// </summary>
        /// <param name="password">string password</param>
        /// <returns>return SHA512 hash</returns>
        private string HashPassword(string password)
        {
            return SwatIncCrypto.SwatIncCrypto.SwatIncSecurityCreateHashSHA512(password);
        }

        /// <summary>
        /// Hashes the password and compares with the hash from database
        /// </summary>
        /// <param name="password">string password</param>
        /// <param name="goodHash">Good hash from database</param>
        /// <returns>boolean to indicate whether the password is a match</returns>
        private bool VerifyPassword(string password, string goodHash)
        {
            return SwatIncCrypto.SwatIncCrypto.VerifyPassword(password, goodHash);
        }
    }
}
