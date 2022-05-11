using ExploringSelfSovereignIdentityAPI.Models.Default;
using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
using ExploringSelfSovereignIdentityAPI.Repositories.SessionRepository;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository repository)
        {
            _sessionRepository = repository;
        }
        public async Task<DefaultIdentityModel> GetMockDefaultIdentity(DefaultIdentityModel e)
        {
            return await _sessionRepository.GetMockDefaultIdentity(e);
        }

        public async Task<DefaultSessionModel> GetMockDefaultSession(DefaultSessionModel e)
        {
            return await _sessionRepository.GetMockSession(e);
        }
    }
}
