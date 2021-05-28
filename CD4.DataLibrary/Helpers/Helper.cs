using CD4.DataLibrary.DiskIO;
using CD4.DataLibrary.Models;
using Newtonsoft.Json;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Helpers
{
    public class SqlDataAccessHelper
    {
        public string GetConnectionString(string name = "CD4Data")
        {
            return ReadConnectionString(name);
        }

        private string ReadConnectionString(string name)
        {
            var reader = new Reader();
            var config = JsonConvert.DeserializeObject<Config>(reader.ReadConfigFile());
            if (config is null) { throw new Exception("Cannot read config file."); }

            var configData = config.ConnectionName.Where((x) => x.Name == name).FirstOrDefault();
            if (configData is null) { throw new Exception($"Cannot find the specified connection [{name}]"); }

            return configData.ConnectionString;
        }
    }
}
