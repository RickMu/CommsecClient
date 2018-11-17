using Newtonsoft.Json;

namespace CommSecClient
{
    public class Request<T>
    {
        public Request(T request)
        {
            Data = JsonConvert.SerializeObject(request);
        }
        [JsonProperty("data")]
        public string Data { get; set; }
    }
}