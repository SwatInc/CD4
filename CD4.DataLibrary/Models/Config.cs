using Newtonsoft.Json;
using System.Collections.Generic;

namespace CD4.DataLibrary.Models
{
    public partial class Config
    {
        [JsonProperty("ConnectionName")]
        public List<ConnectionName> ConnectionName { get; set; }
    }
}
