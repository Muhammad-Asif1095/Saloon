using Newtonsoft.Json;
using Saloon.DataViewModels.Request.Admin.v1;

namespace Saloon.DataViewModels.Response.Admin.v1
{
    public class GetUsersResponse : ListGeneralModel
    {
        [JsonProperty(PropertyName = "users")]
        public List<CreateUserRequest> Users { get; set; } = new List<CreateUserRequest>();
    }
}
