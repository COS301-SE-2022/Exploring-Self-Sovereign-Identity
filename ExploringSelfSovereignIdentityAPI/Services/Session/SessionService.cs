using ExploringSelfSovereignIdentityAPI.Models.Response;
using ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace ExploringSelfSovereignIdentityAPI.Services
{
    public class SessionService : ISessionService
    {
        private Random random;
        private static Dictionary<long, CredentialResponseBase> activeSesions = new Dictionary<long, CredentialResponseBase>();

        private CredentialResponseBase defaultCred;

        public SessionService()
        {
            random = new Random();

            if (activeSesions == null) activeSesions = new Dictionary<long, CredentialResponseBase>();

            defaultCred = new CredentialResponseBase();
            //activeSesions.Add(0000, defaultCred);
        }

        public OtpResponse initializeSession()
        {
            long temp;

            do
            {
                temp = random.NextInt64(0, 10000);
            }
            while (activeSesions.ContainsKey(temp));

            OtpResponse resp = new OtpResponse();
            resp.otp = temp;

            activeSesions.Add(temp, defaultCred);

            return resp;
        }

        public OtpConnectResponse connect(long otp, CredentialResponseBase credential)
        {
            OtpConnectResponse ret = new OtpConnectResponse();
            ret.status = "success";

            if (activeSesions.ContainsKey(otp)) {
                activeSesions[otp] = credential;
                return ret; 
            }

            ret.status = "failed";
            return ret;
        }

        public CredentialResponseBase finish(long otp)
        {
            if (!activeSesions.ContainsKey(otp)) return null;

            CredentialResponseBase ret = (CredentialResponseBase) activeSesions[otp];
            activeSesions.Remove(otp);
            return ret;
        }

    }
}
