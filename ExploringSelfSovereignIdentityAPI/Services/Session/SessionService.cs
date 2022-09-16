using ExploringSelfSovereignIdentityAPI.Models.Response;
using ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services
{
    public class SessionService : ISessionService
    {
        private Random random;
        private Hashtable activeSesions;

        public SessionService()
        {
            random = new Random();
            activeSesions = new Hashtable();
        }

        public OtpConnectResponse connect(string otp, CredentialResponseBase credential)
        {
            OtpConnectResponse ret = new OtpConnectResponse();
            ret.status = "failed";

            if (!activeSesions.ContainsKey(otp)) return ret;

            ret.status = "success";
            activeSesions[otp] = credential;
            return ret;
        }

        public CredentialResponseBase finish(string otp)
        {
            CredentialResponseBase ret = (CredentialResponseBase) activeSesions[otp];
            activeSesions.Remove(otp);
            return ret;
        }

        public OtpResponse initializeSession(string organization)
        {
            long temp;

            do
            {
                temp = random.NextInt64(0, 10000);
            }
            while (activeSesions.ContainsKey(temp.ToString()));

            OtpResponse resp = new OtpResponse();
            resp.otp = temp.ToString();

            return resp;
        }
    }
}
