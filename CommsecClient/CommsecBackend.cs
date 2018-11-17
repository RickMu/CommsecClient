using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit;

namespace CommSecClient
{
    public class CommsecBackend
    {
        public static string origin = "https://app.commsec.com.au";
        static string url = "https://app.commsec.com.au/v5/services/service.svc";
        private readonly ICommSecApi commsecClient;

        private static HttpClient client;

        private string _requestToken;
        private string _accountNumber;
        public CommsecBackend()
        {
            client = new HttpClient(new DebugLoggingHandler()){ BaseAddress = new Uri(url)};
            commsecClient = RestService.For<ICommSecApi>(client);
        }

        public async Task<bool> RequireLogin()
        {
            try
            {
               var response = await GetWatchListAsync();
               return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<WatchList> GetWatchListAsync()
        {
            var response = await commsecClient.GetWatchList();
            
            return await Task.FromResult(response.WatchLists.First());
        }
        public async Task<LoginResponse> LoginAsync(LoginRequest login)
        {
            var response =  await commsecClient.Login(new Request<LoginRequest> (login));
            _requestToken = response.RequestToken;
            _accountNumber = response.Accounts[0].AccountNumber;
            return await Task.FromResult(response);
        }

        public async Task<IList<StockOverview>> GetStockInfos(IDictionary<string,string> stockCodes)
        {
            var request = new StockInfoRequest{StockWithHash = stockCodes};
            var response = await commsecClient.GetStockInfos(new Request<StockInfoRequest> (request));
            
            return await Task.FromResult(response.StockOverviews);
        }

        public async Task<OrderStepResponse> BuyStep1 (string code, int quantity, double price)
        {
            var request = new OrderRequest
            {
                Code = code,
                LimitPrice = price.ToString(),
                Quantity = quantity.ToString(),
                Step = 1,
                AccountNumber = _accountNumber,
                RequestToken = _requestToken,
                OrderType = "BUY"
            };
            return await commsecClient.SendOrder(new Request<OrderRequest> (request));
        }
        public async Task<OrderStepResponse> BuyStep2 (OrderStepResponse step1Response)
        {
            var request = ToOrderRequest(step1Response);
            var response = await commsecClient.SendOrder(new Request<OrderRequest> (request));
            
            _requestToken = response.RequestToken;

            return await Task.FromResult(response);
        }

        public async Task<OrderStepResponse> Buy (string code, int quantity, double price)
        {
            var orderConfirmation = await BuyStep1(code, quantity, price);
            var orderSubtmitResponse = await BuyStep2(orderConfirmation);
            _requestToken = string.IsNullOrEmpty(orderSubtmitResponse.RequestToken) ? _requestToken : orderSubtmitResponse.RequestToken;
            return await Task.FromResult(orderSubtmitResponse);
        }

        public async Task<GetOrdersResponse> GetOrders()
        {
            return await commsecClient.GetOrders(new GetOrdersParam{ AccountNumber = _accountNumber});
        }

        public async Task<CancelOrderResponse> CancelOrder(long orderId)
        {
            var cancelRequest = new CancelOrderRequest
            {
                RequestToken = _requestToken,
                AccountNumber = _accountNumber,
                OrderId = orderId,
            };
            var response = await commsecClient.CancelOrder(new Request<CancelOrderRequest> (cancelRequest));
            _requestToken = response.RequestToken;
            
            return await Task.FromResult(response);
        }

        public OrderRequest ToOrderRequest(OrderStepResponse s1Resp)
        {
           return new OrderRequest
           {
               LimitPrice = s1Resp.LimitPrice.ToString(),
               Quantity = s1Resp.Quantity.ToString(),
               Step = s1Resp.Step,
               OrderType = s1Resp.OrderType,
               AccountNumber = s1Resp.AccountNumber,
               PriceType = s1Resp.PriceType,
               Expiry = s1Resp.Expiry,
               SecurityCheck = s1Resp.SecurityCheck,
               Code = s1Resp.Code,
               Settlement = s1Resp.Settlement,
               Srn = s1Resp.Srn,
               RequestToken = s1Resp.RequestToken,
               AccountType = s1Resp.AccountNumber,
               brokerage = s1Resp.Brokerage,
           };
        }   
    }
}
