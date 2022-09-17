using ExploringSelfSovereignIdentityAPI.Models.Response;
using ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services
{
    public interface ISessionService
    {
        public OtpResponse initializeSession();
        public OtpConnectResponse connect(long otp, CredentialResponseBase credential);
        public CredentialResponseBase finish(long otp);

    }
}
