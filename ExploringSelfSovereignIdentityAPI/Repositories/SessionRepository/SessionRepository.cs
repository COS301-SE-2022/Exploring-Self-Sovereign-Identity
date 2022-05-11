using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Repositories.SessionRepository
{
    public class SessionRepository : ISessionRepository
    {
        private readonly ISessionRepository _sessionRepository;

        public async Task<DefaultIdentityModel> GetMockDefaultIdentity(DefaultIdentityModel e)
        {
            e.addAttribute("Name", true);
            e.addAttribute("Surame", false);
            e.addAttribute("Email", true);
            e.addAttribute("Number", false);

            await Task.FromResult(e);
            return e;
        }

    }
}
