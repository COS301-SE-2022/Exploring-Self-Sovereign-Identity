using ExploringSelfSovereignIdentityAPI.Controllers.UserData;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain;
using ExploringSelfSovereignIdentityAPI.Services.UserDataService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using IUserDataService = ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain.IUserDataService;

namespace ExploringSelfSovereignIdentityAPI.Services
{
    public class SessionService : ISessionService
    {
        private IUserDataService userData;

        private Random random;
        private static Dictionary<long, CredentialResponseBase> activeSesions = new Dictionary<long, CredentialResponseBase>();

        private CredentialResponseBase defaultCred;

        public SessionService(IUserDataService userData)
        {
            random = new Random();

            if (activeSesions == null) activeSesions = new Dictionary<long, CredentialResponseBase>();

            defaultCred = new CredentialResponseBase();

            this.userData = userData;
        }

        public OtpResponse initializeSession()
        {
            long temp;

            do
            {
                temp = random.NextInt64(1000, 10000);
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

        public async Task<OtpConnectResponse> issue(string id, CredentialResponseBase credential)
        {
            UpdateGen2 u = new UpdateGen2();
            u.Id = id;
            u.Credentials = new List<CredentialUpdateGen2>();

            CredentialUpdateGen2 c = new CredentialUpdateGen2();

            c.Organization = credential.Organization;
            c.Attributes = credential.Attributes;
            c.Index = -1;

            u.Credentials.Add(c);

            u.Attributes = new List<AttributeUpdateGen2>();

            await userData.updateUserData(u);

            OtpConnectResponse ret = new OtpConnectResponse();
            ret.status = "success";
            return ret;
        }

    }
}
