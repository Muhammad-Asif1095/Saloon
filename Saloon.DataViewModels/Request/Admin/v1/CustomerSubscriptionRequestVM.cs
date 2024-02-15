using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saloon.DataViewModels.Request.Admin.v1
{
    public class CustomerSubscriptionRequestVM
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        [Required]
        [JsonProperty(PropertyName = "packageid")]
        public Guid PackageId { get; set; }
        [Required]
        [JsonProperty(PropertyName = "signedon")]
        public DateTime SignedOn { get; set; }
        [Required]
        [JsonProperty(PropertyName = "validthrough")]
        public DateTime ValidThrough { get; set; }
        [JsonProperty(PropertyName = "customerid")]
        public Guid? CustomerId { get; set; }
    }
}
