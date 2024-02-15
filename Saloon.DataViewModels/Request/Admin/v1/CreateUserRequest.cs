using Newtonsoft.Json;
using Saloon.DataViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saloon.DataViewModels.Request.Admin.v1
{
    public class CreateUserRequest
    {
        [JsonProperty(PropertyName = "id")]
        public Guid? Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [Required]
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [Required]
        [JsonProperty(PropertyName = "countryCode")]
        public string CountryCode { get; set; }

        [Required]
        [JsonProperty(PropertyName = "phoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [JsonProperty(PropertyName = "roleId")]
        public Guid RoleId { get; set; }

        [JsonProperty(PropertyName = "customerId")]
        public Guid? CustomerId { get; set; }

        [JsonProperty(PropertyName = "branchId")]
        public Guid? BranchId { get; set; }

        [JsonProperty(PropertyName = "roleName")]
        public string RoleName { get; set; }
        public Guid UserTypeId { get; set; }

        public DateTime BirthDate { get; set; }

        public int Age { get; set; }

        public bool? IsMale { get; set; }
    }
}
