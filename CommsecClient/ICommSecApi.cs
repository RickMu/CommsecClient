using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit;

namespace CommSecClient
{

    [Headers("Content-Type: application/json; chatset=UTF-8", "Origin: https://app.commsec.com.au")]
    public interface ICommSecApi
    {
        [Post("/login")]
        Task<LoginResponse> Login([Body]Request<LoginRequest> login);

        
        [Get("/watchlists")]
        Task<WatchListResponse> GetWatchList([Body]string val = "");

        [Post("/getStockInfos")]
        Task<StockOverviewResponse> GetStockInfos([Body(buffered: true)]Request<StockInfoRequest> request);

        [Post("/placeneworder")]
        Task<OrderStepResponse> SendOrder([Body]Request<OrderRequest> request);

        [Get("/getorders")]
        Task<GetOrdersResponse> GetOrders(GetOrdersParam param,[Body] string val = "");

        [Post("/cancelorder")]
        Task<CancelOrderResponse> CancelOrder([Body] Request<CancelOrderRequest> rquest);

    }

    public class GetOrdersResponse: ResponseBase
    {
        [JsonProperty("accountNumber")]
        public string AccountNumber { get;set; }
        
        [JsonProperty("accountName")]
        public string AccountName { get;set; }
        
        [JsonProperty("cancelledOrders")]
        public IList<Order> CancelledOrders { get;set; }
        
        [JsonProperty("executedOrders")]
        public IList<Order> ExecutedOrders { get;set; }
        
        [JsonProperty("outstandingOrders")]
        public IList<Order> OutstandingOrders { get;set; }
        
        [JsonProperty("enableTradingPassword")]
        public bool EnableTradingPassword { get;set; }
        
        [JsonProperty("tradingPassword")]
        public string TradingPassword { get;set; }
    }
    public class GetOrdersParam
    {
        [AliasAs("accountNumber")]
        public string AccountNumber { get;set; }
        [AliasAs("maxLength")]
        public int MaxLength { get;set; }= 20;
    }

    public class Order
    {
        [JsonProperty("cancellationDate")]
        public string CancellationDate { get;set; }
        
        [JsonProperty("executedDate")]
        public string ExecuteDate { get;set; }
        
        [JsonProperty("executedPrice")]
        public double ExecutedPrice { get;set; }
        
        [JsonProperty("executedQty")]
        public double ExecutedQty { get;set; }
        [JsonProperty("expiry")]
        public string Expiry { get;set; }
        
        [JsonProperty("limitPrice")]
        public double LimitPrice { get;set; }
        
        [JsonProperty("orderDate")]
        public string OrderDate { get;set; }
        
        [JsonProperty("orderId")]
        public long OrderId { get;set; }
        
        [JsonProperty("orderNumber")]
        public string OrderNumber { get;set; }
        
        [JsonProperty("outstandingQty")]
        public double OutstandingQty { get;set; }
        
        [JsonProperty("priceType")]
        public string PriceType { get;set; }
        
        [JsonProperty("qty")]
        public double Qty { get;set; }
        
        [JsonProperty("status")]
        public string Status { get;set; }
        
        [JsonProperty("stockCode")]
        public string StockCode { get;set; }
        
        [JsonProperty("stockName")]
        public string StockName { get;set; }
        
        [JsonProperty("type")]
        public string Type { get;set; }
    }
    public class CancelOrderResponse:ResponseBase
        {
            [JsonProperty("hasError")]
            public bool HasError { get;set; }
            [JsonProperty("orderDidCancel")]
            public bool OrderDidCancel { get;set; }
            [JsonProperty("vettingResults")]
            public VettingResults vettingResults { get;set; }
        }
        public class CancelOrderRequest
        {
            [JsonProperty("requestToken")]
            public string RequestToken { get;set; }
            [JsonProperty("accountId")]
            public string AccountNumber { get;set; }
            [JsonProperty("orderId")]
            public long OrderId { get;set; }
        }
}
