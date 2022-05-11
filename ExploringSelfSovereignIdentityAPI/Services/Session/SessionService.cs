using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionService _sessionService;

        public SessionService(ISessionService repository)
        {
            _sessionService = repository;
        }
        public async Task<DefaultIdentityModel> GetMockDefaultIdentity(DefaultIdentityModel e)
        {
            return await _sessionService.GetMockDefaultIdentity(e);
        }
    }
}
