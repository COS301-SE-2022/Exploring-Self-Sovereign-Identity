using ExploringSelfSovereignIdentityAPI.Models.Default;
using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
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
    }
}
