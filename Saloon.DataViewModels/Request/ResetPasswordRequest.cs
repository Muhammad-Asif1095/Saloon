using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Saloon.DataViewModels.Request
{
    public class ResetPasswordRequest
    {
        [Required]
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "newPassword")]
        public string NewPassword { get; set; }
    }
}
