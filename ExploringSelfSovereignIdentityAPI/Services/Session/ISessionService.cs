using ExploringSelfSovereignIdentityAPI.Models.Response;
using ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services
{
    public interface ISessionService
    {
        public OtpResponse initializeSession();
        public OtpConnectResponse connect(string otp, CredentialResponseBase credential);
        public CredentialResponseBase finish(string otp);

    }
}
