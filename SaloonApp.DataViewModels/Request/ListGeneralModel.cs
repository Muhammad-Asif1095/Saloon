using Newtonsoft.Json;
using SaloonApp.DataViewModels.Common;

namespace SaloonApp.DataViewModels.Request
{
    public class ListGeneralModel
    {
        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }

        [JsonProperty(PropertyName = "pageSize")]
        public int PageSize { get; set; }

        [JsonProperty(PropertyName = "totalRecords")]
        public int TotalRecords { get; set; }

        [JsonProperty(PropertyName = "search")]
        public string Search { get; set; }

        [JsonProperty(PropertyName = "sortBy")]
        public List<RequestResponseSort> SortBy { get; set; } = new List<RequestResponseSort>();

        [JsonProperty(PropertyName = "parentId")]
        public Guid? ParentId { get; set; }

        [JsonProperty(PropertyName = "id")]
        public Guid? Id { get; set; }

        [JsonProperty(PropertyName = "startDate")]
        public DateTime? StartDate { get; set; }

        [JsonProperty(PropertyName = "endDate")]
        public DateTime? EndDate { get; set; }
    }
    public class ListRouteModel : ListGeneralModel
    {
        public Guid? sourceId { get; set; }
        public List<Guid>? AssignedToId { get; set; }
        public Guid? BranchId { get; set; }
    }
    public class ListGeneralRouteScheduleModel
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

        [JsonProperty(PropertyName = "parentId")]
        public Guid? ParentId { get; set; }

        [JsonProperty(PropertyName = "startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty(PropertyName = "endDate")]
        public DateTime EndDate { get; set; }

        [JsonProperty(PropertyName = "id")]
        public Guid? Id { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public List<Guid>? UserId { get; set; }

        [JsonProperty(PropertyName = "routeStatus")]
        public Guid? RouteStatus { get; set; }
        public Guid? BranchId { get; set; }
    }

    public class ListOldModel
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
        public string SortBy { get; set; }

        [JsonProperty(PropertyName = "parentId")]
        public Guid? ParentId { get; set; }
    }
}