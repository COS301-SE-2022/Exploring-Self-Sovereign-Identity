using ExploringSelfSovereignIdentityAPI.Models.Default;
using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
﻿using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services
{
    public interface ISessionService
    {
        Task<DefaultIdentityModel> GetMockDefaultIdentity(DefaultIdentityModel e);

        Task<DefaultSessionModel> GetMockDefaultSession(DefaultSessionModel e);

        Task<DefaultIdentityResponse> confirmIdentity(DefaultIdentityModel e);

        Task<OtpResponse> GetOtpResponse(OtpResponse e);
    }
}
