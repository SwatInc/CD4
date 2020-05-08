using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CD4.DataLibrary.Models
{

    public partial class ConnectionName
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ConnectionString")]
        public string ConnectionString { get; set; }

        [JsonProperty("Provider")]
        public string Provider { get; set; }
    }
}
