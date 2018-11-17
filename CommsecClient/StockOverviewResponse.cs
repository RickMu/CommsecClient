using System.Collections.Generic;
using Newtonsoft.Json;

namespace CommSecClient
{
    public class StockOverviewResponse: ResponseBase
    {
        [JsonProperty("stockInfos")]
        public IList<StockOverview> StockOverviews {get;set;}
    }
}
