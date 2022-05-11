using ExploringSelfSovereignIdentityAPI.Models.Default;
using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
﻿using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using System;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Repositories.SessionRepository
{
    public class SessionRepository : ISessionRepository
    {
        public async Task<DefaultIdentityModel> GetMockDefaultIdentity(DefaultIdentityModel e)
        {
            e.addAttribute("Name", true);
            e.addAttribute("Surame", false);
            e.addAttribute("Email", true);
            e.addAttribute("Number", false);

            return await Task.FromResult(e);
        }

        public async Task<DefaultSessionModel> GetMockSession(DefaultSessionModel e)
        {
            e.SessionId = 11111;
            e._identity = await GetMockDefaultIdentity(new DefaultIdentityModel());

            return await Task.FromResult(e);
        }
        public async Task<DefaultIdentityResponse> confirmIdentity(DefaultIdentityModel e)
        {
            DefaultIdentityResponse response = new DefaultIdentityResponse();

            response.identity = e;
            response.token = "fwerwehvuvgvyvdwewmp5fwfewbiybjjhgyvbue";

            return await Task.FromResult(response);
        }

        public async Task<OtpResponse> GetOtpResponse(OtpResponse e)
        {
            //throw new NotImplementedException();
            OtpResponse response = new OtpResponse();
            response.otp = "123456";

            return await Task.FromResult(response);
        }
    }
}
