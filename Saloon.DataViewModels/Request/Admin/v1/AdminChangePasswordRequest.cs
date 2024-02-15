using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Saloon.DataViewModels.Request.Admin.v1
{
    public class AdminChangePasswordRequest
    {
        [Required]
        [JsonProperty(PropertyName = "userId")]
        public Guid UserId { get; set; }
        [Required]
        [JsonProperty(PropertyName = "newPassword")]
        public string NewPassword { get; set; } = "";
    }
}
