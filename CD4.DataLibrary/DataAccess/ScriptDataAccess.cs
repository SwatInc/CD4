using System;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class ScriptDataAccess : DataAccessBase, IScriptDataAccess
    {
        public async Task<string> LoadScriptByName(string name)
        {
            var storedProcedure = "[dbo].[usp_LoadScriptByName]";
            var parameter = new { Name = name };

            try
            {
                return await SelectInsertOrUpdateAsync<string, dynamic>(storedProcedure, parameter);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
