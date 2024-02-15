using Newtonsoft.Json;

namespace Saloon.DataViewModels.Response
{
    public class AdminLoginResponse
    {
        [JsonProperty(PropertyName = "accessToken")]
        public string AccessToken { get; set; } = "";
        [JsonProperty(PropertyName = "username")]
        public string username { get; set; } = "";

  }
}
