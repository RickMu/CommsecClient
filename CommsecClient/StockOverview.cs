using Newtonsoft.Json;

namespace CommSecClient
{
    public class StockOverview
    {
        [JsonProperty("bid")]
        double Bid { get; set; }
        
        [JsonProperty("code")]
        string Code { get; set; }
        
        [JsonProperty("hash")]
        public string Hash { get; set; }
        
        [JsonProperty("high")]
        double High { get; set; }
        
        [JsonProperty("lastPrice")]
        double LastPrice {get;set;}
        
        [JsonProperty("low")]
        double Low { get; set; }
        
        [JsonProperty("name")]
        string Name { get; set; }
        
        [JsonProperty("offer")]
        double Offer { get; set; }
        
        [JsonProperty("open")]
        double Open { get; set; }
        
        [JsonProperty("volume")]
        long Volume { get; set; }

        public override string ToString()
        {
            return $"[Stock] Code:{Code}, Name:{Name}, High:{High}, Low:{Low}, Bid:{Bid}, Offer:{Offer}, Open:{Open}, Volume:{Volume}";
        }
    }
}
