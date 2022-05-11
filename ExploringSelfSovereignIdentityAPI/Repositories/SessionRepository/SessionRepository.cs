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

    }
}
