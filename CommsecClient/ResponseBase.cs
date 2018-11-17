using Newtonsoft.Json;

namespace CommSecClient
{
    public class ResponseBase
    {
        [JsonProperty("message")]
        public string Message {get;set;}
        
        [JsonProperty("messages")]
        public string Messages {get;set;}
        
        [JsonProperty("requestToken")]
        public string RequestToken {get;set;}
        
        [JsonProperty("status")]
        public string Status {get;set;}
    }
}