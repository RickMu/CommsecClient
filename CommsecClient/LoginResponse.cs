using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace CommSecClient
{
    public class LoginResponse: ResponseBase
    {
        
        [JsonProperty("accounts")]

        public IList<Account> Accounts { get; set;}
        
        [JsonProperty("UserName")]
        public string UserName { get; set; }

        public override string ToString()
        {
            return $"{nameof(RequestToken)}:{RequestToken}, {nameof(Accounts)}:{string.Join("|",Accounts.Select( x=> x.ToString()))}, {nameof(UserName)}:{UserName}";
        }
    }

    public class Account
    {

        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        public override string ToString()
        {
            return $"{nameof(AccountNumber)}: {AccountNumber}";
        }
    }
}