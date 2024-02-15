using Newtonsoft.Json;

namespace Saloon.DataViewModels.Common
{
    public class UploadDocument
    {
        [JsonProperty(PropertyName = "type")]
        public int Type { get; set; } = 0;
    }
}
