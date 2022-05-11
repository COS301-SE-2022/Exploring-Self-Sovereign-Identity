using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;

namespace ExploringSelfSovereignIdentityAPI.Models.Default
{
    public class DefaultSessionModel
    {
        public DefaultIdentityModel _identity { get; set; }
        public short SessionId { get; set; }
    }
}
