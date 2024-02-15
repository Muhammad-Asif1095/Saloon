using Newtonsoft.Json;
using Saloon.DataViewModels.Common;

namespace Saloon.DataViewModels.Response.Admin.v1
{
    public class ListGeneralModel
    {
        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }

        [JsonProperty(PropertyName = "pageSize")]
        public int PageSize { get; set; }

        [JsonProperty(PropertyName = "totalRecords")]
        public int TotalRecords { get; set; }

        [JsonProperty(PropertyName = "sortIndex")]
        public int SortIndex { get; set; } = -1;

        [JsonProperty(PropertyName = "search")]
        public string Search { get; set; }

        [JsonProperty(PropertyName = "sortBy")]
        public List<RequestResponseSort> SortBy { get; set; } = new List<RequestResponseSort>();

        [JsonProperty(PropertyName = "id")]
        public Guid? Id { get; set; }
    }
}
