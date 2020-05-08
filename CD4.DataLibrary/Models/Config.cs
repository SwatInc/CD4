using Newtonsoft.Json;

namespace CD4.DataLibrary.Models
{
    public partial class Config
    {
        [JsonProperty("ConnectionName")]
        public ConnectionName ConnectionName { get; set; }
    }
}
