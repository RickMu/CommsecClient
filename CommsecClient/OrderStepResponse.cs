using System.Collections.Generic;
using Newtonsoft.Json;

namespace CommSecClient
{
    public class OrderStepResponse: ResponseBase
    {
        [JsonProperty("limitPrice")]
        public double LimitPrice { get;set; }
        
        [JsonProperty("quantity")]
        public int Quantity { get;set; }
        
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
        
        [JsonProperty("accountType")]
        public string AccountType {get;set;} = "Shares";
        [JsonProperty("dateCreated")]
        public string DateCreated { get;set; }
        
        [JsonProperty("enableTradingPassword")]
        public string EnableTradingPassword { get;set; }
        
        [JsonProperty("isProxy")]
        public string IsProxy { get;set; }
        
        [JsonProperty("consideration")]
        public double Consideration { get;set; }
        
        [JsonProperty("hasError")]
        public bool HasError { get;set; }
        
        [JsonProperty("orderValue")]
        public int OrderValue { get;set; }
        
        [JsonProperty("quotationDate")]
        public string QuotationDate { get;set; }

        [JsonProperty("orderStatus")]
        public string OrderStatus { get;set; }

        [JsonProperty("brokerage")]
        public string Brokerage { get;set; }
        public override string ToString()
        {
            return $"Success: {Status}, Code: {Code}, Quantity: {Quantity}, Price: {LimitPrice}";
        }
        
        [JsonProperty("vettingResults")]
        public VettingResults vettingResult { get;set; }


    }
    public class VettingResults
    {
        [JsonProperty("ExpandVettingMessagesByDefault")]
        public bool ExpandVettingMessageByDefault { get;set; }

        [JsonProperty("vettingMessages")]
        public IList<VettingMessage> VettingMessages { get;set; }
    }

    public class VettingMessage
    {
        [JsonProperty("longDescription")]
        public string LongDescription { get;set; }
    }
}
