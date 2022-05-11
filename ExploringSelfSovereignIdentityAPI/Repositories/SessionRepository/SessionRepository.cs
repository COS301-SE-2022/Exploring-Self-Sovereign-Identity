using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
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

        public async Task<DefaultIdentityResponse> confirmIdentity(DefaultIdentityModel e)
        {
            DefaultIdentityResponse response = new DefaultIdentityResponse();

            response.identity = e;
            response.token = "fwerwehvuvgvyvdwewmp5fwfewbiybjjhgyvbue";

            return await Task.FromResult(response);
        }

    }
}
