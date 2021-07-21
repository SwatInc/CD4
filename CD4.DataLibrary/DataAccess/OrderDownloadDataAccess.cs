using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class OrderDownloadDataAccess : DataAccessBase, IOrderDownloadDataAccess
    {
        public async Task<List<OrdersDownloadModel>> DownloadAllOrdersForAnalyserAsync(string analyserName, int usersId)
        {
            var parameters = new { AnalyserName = analyserName, UsersId = usersId };
            try
            {
                var storedProcedure = "[dbo].[usp_GetAllAcceptedTestOrdersForAnalyser]";
                return await LoadDataWithParameterAsync<OrdersDownloadModel, dynamic>(storedProcedure, parameters);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<List<OrdersDownloadModel>> DownloadAllAnalyserSpecificOrdersForQueriedSampleAsync(string analyserName, string sid, int usersId)
        {
            var parameters = new { AnalyserName = analyserName, Sid = sid, UsersId = usersId };
            try
            {
                var storedProcedure = "[dbo].[usp_GetAllAnalyserSpecificAcceptedTestOrdersForSample]";
                return await LoadDataWithParameterAsync<OrdersDownloadModel, dynamic>(storedProcedure, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
