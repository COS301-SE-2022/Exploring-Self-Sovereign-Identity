using ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain;

namespace ExploringSelfSovereignIdentityAPI.Models.Request
{
    public class ConnectRequest
    {
        public string otp { get; set; }
        public CredentialResponseBase credential { get; set; }
    }
}
