using Newtonsoft.Json;
using SaloonApp.DataViewModels.Request;

namespace SaloonApp.DataViewModels.Response
{
    public class ListResponse<T> : ListGeneralModel
    {
        [JsonProperty(PropertyName = "data")]
        public List<T> Data { get; set; } = new List<T>();
    }
}
