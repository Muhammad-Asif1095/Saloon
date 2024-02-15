using Newtonsoft.Json;

namespace Saloon.DataViewModels.Common
{
    public class PhoneNumberModel
    {
        [JsonProperty(PropertyName = "countryCode")]
        public string CountryCode { get; set; } = "";

        [JsonProperty(PropertyName = "phoneNumber")]
        public string PhoneNumber { get; set; } = "";
    }
}
