using ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain;

namespace ExploringSelfSovereignIdentityAPI.Models.Request
{
    public class IssueCredentialRequest
    {
        public string id { get; set; }
        public CredentialResponseBase credential { get; set; }
    }
}
