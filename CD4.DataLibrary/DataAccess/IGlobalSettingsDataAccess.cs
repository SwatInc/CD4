using CD4.DataLibrary.Models;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IGlobalSettingsDataAccess
    {
        Task<GlobalSettingsModel> ReadAllGlobalSettingsAsync();
        Task UpdateGlobalSetting(GlobalSettingsModel globalSettings);
    }
}