using System.Collections.Generic;
using Newtonsoft.Json;

namespace CommSecClient
{
    public class WatchListResponse: ResponseBase
    {
        [JsonProperty("lists")]
        public IList<WatchList> WatchLists {get; set;}
    }
}
