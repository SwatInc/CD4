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
            if (config.ConnectionName.Name == name)
            {
                return config.ConnectionName.ConnectionString;
            }
            else
            {
                throw new ArgumentException($"Cannot find connection string by the name: {name}");
            }

        }
    }
}
