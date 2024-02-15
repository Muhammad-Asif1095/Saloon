using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Saloon.DataViewModels.Request.Admin.v1
{
    public class AssignRight
    {
        [Required]
        [JsonProperty(PropertyName = "roleId")]
        public Guid RoleId { get; set; }

        [Required]
        [JsonProperty(PropertyName = "rightIds")]
        public List<Guid> RightIds { get; set; }
    }
}
