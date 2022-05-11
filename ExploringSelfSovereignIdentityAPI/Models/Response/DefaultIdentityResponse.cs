using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;

namespace ExploringSelfSovereignIdentityAPI.Models.Response
{
    public class DefaultIdentityResponse
    {
        public DefaultIdentityModel identity { get; set; }
        public string token { get; set; }

        public DefaultIdentityResponse()
        {
            identity = new DefaultIdentityModel();
        }
    }
}
