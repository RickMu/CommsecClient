using Newtonsoft.Json;

namespace CommSecClient
{
    public class LoginRequest
    {
        [JsonProperty("clientId")]
        public string ClientId { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("loginType")]
        public string LoginType { get; set; }
        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }
    }
}