using ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain;

namespace ExploringSelfSovereignIdentityAPI.Models.Request
{
    public class IssueCredentialRequest
    {
        public CredentialResponseBase credential { get; set; }
        public string id { get; set; }
    }
}
