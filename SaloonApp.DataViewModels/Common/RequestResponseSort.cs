using Newtonsoft.Json;

namespace SaloonApp.DataViewModels.Common
{
    public class RequestResponseSort
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "direction")]
        public string Direction { get; set; }
    }
}