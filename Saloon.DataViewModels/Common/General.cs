using Newtonsoft.Json;

namespace Saloon.DataViewModels.Common
{
    public class General<T>
    {
        [JsonProperty(PropertyName = "id")]
        public T Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
