using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class GlobalSettingsDataAccess : DataAccessBase, IGlobalSettingsDataAccess
    {
        public async Task<GlobalSettingsModel> ReadAllGlobalSettingsAsync()
        {
            var storedProcedure = "[dbo].[usp_ReadGlobalSettings]";
            return  (await LoadDataAsync<GlobalSettingsModel>(storedProcedure)).FirstOrDefault();
        }

        public async Task UpdateGlobalSetting(GlobalSettingsModel globalSettings)
        {
            var storedProcedure = "[dbo].[usp_UpdateGlobalSettings]";
            _ = await LoadDataAsync<dynamic>(storedProcedure);
        }
    }
}
