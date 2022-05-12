using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Models.Response
{
    public class DefaultIdentityResponse
    {
        public Dictionary<string,string> identity { get; set; }
        public string token { get; set; }

        public DefaultIdentityResponse()
        {
            identity = new Dictionary<string, string>();
        }
    }
}
