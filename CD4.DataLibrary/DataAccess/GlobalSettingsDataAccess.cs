using CD4.DataLibrary.Models;
using Newtonsoft.Json;
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
            try
            {
                var storedProcedure = "[dbo].[usp_ReadGlobalSettings]";
                var jsonSettings  = (await LoadDataAsync<string>(storedProcedure)).FirstOrDefault();

                if (!string.IsNullOrEmpty(jsonSettings))
                {
                    return JsonConvert.DeserializeObject<GlobalSettingsModel>(jsonSettings);
                }

                throw new Exception("Cannot read global settings!");
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task UpdateGlobalSetting(GlobalSettingsModel globalSettings)
        {
            if (globalSettings is null) { throw new Exception("Global settings cannot be null"); }
            try
            {
                var storedProcedure = "[dbo].[usp_UpdateGlobalSettings]";
                var parameter = new { JsonSettings = JsonConvert.SerializeObject(globalSettings) };

                _ = await LoadDataAsync<dynamic>(storedProcedure);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
