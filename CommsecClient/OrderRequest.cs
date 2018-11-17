using Newtonsoft.Json;

namespace CommSecClient
{
    public class OrderRequest
    {
        [JsonProperty("limitPrice")]
        public string LimitPrice { get;set; }
        
        [JsonProperty("quantity")]
        public string Quantity { get;set; }
        
        [JsonProperty("step")]
        public int Step { get;set; }
        
        [JsonProperty("orderType")]
        public string OrderType { get; set; }
        
        [JsonProperty("accountNumber")]
        public string AccountNumber { get;set; }
        
        [JsonProperty("priceType")]
        public string PriceType { get;set; } = "LIMIT";
        
        [JsonProperty("expiry")]
        public string Expiry { get; set; } = "20 DAYS";
        
        [JsonProperty("securityCheck")]
        public string SecurityCheck { get;set; } = string.Empty;
        
        [JsonProperty("code")]
        public string Code { get;set; }
        
        [JsonProperty("settlement")]
        public string Settlement { get;set; } = "CHESS"; 
        
        [JsonProperty("srn")]
        public string Srn {get;set;} = string.Empty;
        
        [JsonProperty("requestToken")]
        public string RequestToken {get;set;}
        
        [JsonProperty("accountType")]
        public string AccountType {get;set;} = "Shares";

        [JsonProperty("proxyClientPhoneNumber")]
        public string ProxyClientPhoneNumber { get;set; } = string.Empty;
        
        [JsonProperty("proxyClientName")]
        public string ProxyClientName { get;set; } = string.Empty;
        
        [JsonProperty("brokerage")]
        public string brokerage { get;set; } = string.Empty;
    }

}
