using CD4.DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IOrderDownloadDataAccess
    {
        Task<List<OrdersDownloadModel>> DownloadAllOrdersForAnalyserAsync(string analyserName, int usersId);
        Task<List<OrdersDownloadModel>> DownloadAllAnalyserSpecificOrdersForQueriedSampleAsync(string analyserName, string sid, int usersId);

    }
}