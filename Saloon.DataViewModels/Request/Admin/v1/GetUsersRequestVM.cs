using Newtonsoft.Json;

namespace Saloon.DataViewModels.Request.Admin.v1
{
    public class GetUsersRequestVM : ListGeneralModel
    {
        [JsonProperty(PropertyName = "facultyid")]
        public Guid? FacultyId { get; set; }
        [JsonProperty(PropertyName = "teamsid")]
        public Guid? TeamsId { get; set; }
        public Guid? BranchId { get; set; }
    }
}
