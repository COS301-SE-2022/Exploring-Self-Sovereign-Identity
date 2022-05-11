using ExploringSelfSovereignIdentityAPI.Models.Default;
using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
﻿using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Repositories.SessionRepository
{
    public interface ISessionRepository
    {
        Task<DefaultIdentityModel> GetMockDefaultIdentity(DefaultIdentityModel e);

        Task<DefaultSessionModel> GetMockSession(DefaultSessionModel e);

        Task<DefaultIdentityResponse> confirmIdentity(DefaultIdentityModel e);
    }
}
