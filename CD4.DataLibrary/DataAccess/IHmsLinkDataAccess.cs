using CD4.DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IHmsLinkDataAccess
    {
        Task<List<HmsLinkDataModel>> GetAnalysisRequestDataByEpisodeNumber(int episodeNumber, string query);
        Task<List<HmsLinkDataModel>> GetAnalysisRequestDataByEpisodeNumberMock(int episodeNumber, string query);
    }
}