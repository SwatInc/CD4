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
            var result = await GetHashForUser(username);
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
                var storedProcedure = "[dbo].[usp_GetUserRoleAndClaims]";
                var parameter = new { username = username };
                var queryResult = await SelectInsertOrUpdateAsync<AuthorizeDetailModel, dynamic>(storedProcedure, parameter);
                //if no claims/roles assigned to the user... queryResult will be null.
                if (queryResult is null)
                {
                    return new AuthorizeDetailModel()
                    {
                        IsAuthenticated = false,
                        Message = $"Authentication is successful but, {username} does not have any permissions assigned on CD4.\n"
                                  + "Please request permissions from the Laboratory Manager."
                    };
                }

                queryResult.IsAuthenticated = true;
                return queryResult;
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

        public async Task ChangePassword(string currentPassword, string username, string newPassword)
        {
            try
            {
                //get user hash
                var usernameAndHash = await GetHashForUser(username);
                if (usernameAndHash is null)
                {
                    throw new Exception($"An error occured while changing the password.\nCannot find user: {username}");
                }
                //verify that the current password match
                if (VerifyPassword(currentPassword,usernameAndHash.PasswordHash))
                {
                    //change the password
                    await ChangeUserHash(newPassword, username);
                }
                else
                {
                    throw new Exception("The current password provided is invalid!");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Fetches the user hash from database with the specified username
        /// </summary>
        /// <param name="username">The username and password</param>
        /// <returns>An instance of UsernameAndHashModel or null </returns>
        private async Task<UsernameAndHashModel> GetHashForUser(string username)
        {
            //get username and password hash from database.
            var storedProcedure = "[dbo].[usp_GetHashForUsername]";
            var parameter = new { username = username };

            try
            {
                return await SelectInsertOrUpdateAsync<UsernameAndHashModel, dynamic>
                    (storedProcedure, parameter);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// updates the database with new password hash
        /// </summary>
        /// <param name="password">The new password</param>
        private async Task ChangeUserHash(string password, string username)
        {
            var storedProcedure = "[dbo].[usp_ChangeUserHash]";
            var parameter = new { PasswordHash = SwatIncCrypto.SwatIncCrypto.SwatIncSecurityCreateHashSHA512(password), UserName = username };
            try
            {
                _ = await SelectInsertOrUpdateAsync<dynamic, dynamic>(storedProcedure, parameter);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
