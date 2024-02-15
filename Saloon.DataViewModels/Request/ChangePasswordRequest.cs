using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Saloon.DataViewModels.Request
{
    public class ChangePasswordRequest
    {
        [Required]
        [JsonProperty(PropertyName = "oldPassword")]
        public string OldPassword { get; set; } = "";

        [Required]
        [JsonProperty(PropertyName = "newPassword")]
        public string NewPassword { get; set; } = "";
    }
}
