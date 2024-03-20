using Newtonsoft.Json;

namespace SaloonApp.DataViewModels.Response
{
    public class AppLoginResponse
    {
        [JsonProperty(PropertyName = "accessToken")]
        public string AccessToken { get; set; } = "";

        [JsonProperty(PropertyName = "isAccountVerified")]
        public bool IsAccountVerified { get; set; } = false;

        [JsonProperty(PropertyName = "username")]
        public string username { get; set; } = "";
    }
}
