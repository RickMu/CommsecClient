using System.Collections.Generic;
using Newtonsoft.Json;

namespace CommSecClient
{
    public class StockInfoRequest
    {
        [JsonProperty("stockCodesWithHash")]
        public IDictionary<string,string> StockWithHash {get; set;}
    }
}
