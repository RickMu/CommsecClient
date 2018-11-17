using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace CommSecClient
{
    public class WatchList
    {
        [JsonProperty("id")]
        int Id { get; set; }
        [JsonProperty("isDefault")]
        bool IsDefault { get; set; }
        [JsonProperty("items")]
        IList<StockOverview> stockOverviews { get; set; }

        public override string ToString()
        {
            var overviewLists = string.Join("|",stockOverviews.Select(x => x.ToString()));
            return $"ListId:{Id}, Items:{overviewLists} ";
        }
    }
}
