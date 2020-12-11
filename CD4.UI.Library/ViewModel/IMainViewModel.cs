using CD4.UI.Library.Model;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public interface IMainViewModel
    {
        Task<List<WorkStationPrintersInfoModel>> GetApplicationWideStaticData();
        int GetloggedInUserId();
        Image GetDisciplineImage(string image);
        Task<List<ResultAlertModel>> GetResultAlertData();
    }
}