using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Saloon.DataViewModels.Request.Admin.v1
{
    public class UpdateRoleRequest
    {
        [Required]
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
