using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Saloon.DataViewModels.Common;

namespace Saloon.DataViewModels.Request
{
    public class SignUpRequest
    {
        [Required]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [Required]
        [JsonProperty(PropertyName = "PhoneNumber")]
        public PhoneNumberModel PhoneNumber { get; set; }
    }
}
