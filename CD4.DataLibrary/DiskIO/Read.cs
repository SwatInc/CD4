using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DiskIO
{
    public  class Reader
    {
        public string ReadConfigFile()
        {
            var configPath = GetConfigFilePath();
            return File.ReadAllText(configPath);
        }

        private string GetConfigFilePath()
        {
            return $"{AppDomain.CurrentDomain.BaseDirectory}\\Config.json";
        }
    }
}
