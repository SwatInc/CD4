using CD4.UI.Library.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public interface IMainViewModel
    {
        Task<List<WorkstationPrintersInfo>> GetApplicationWideStaticData();
    }
}