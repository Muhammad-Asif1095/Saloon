using Newtonsoft.Json;

namespace Saloon.DataViewModels.Response.Admin.v1
{
    public class ListResponse<T> : ListGeneralModel
    {
        [JsonProperty(PropertyName = "data")]
        public List<T> Data { get; set; } = new List<T>();
    }
}
