using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Saloon.DataViewModels.Request
{
    public class AdminLoginRequest
    {
        [Required]
        [JsonProperty(PropertyName = "UserInfo")]
        public string UserInfo { get; set; }

        [Required]
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}
