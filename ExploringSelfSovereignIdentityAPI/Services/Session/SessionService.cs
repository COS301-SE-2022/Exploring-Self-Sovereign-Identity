using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services
{
    public class SessionService : ISessionService
    {
        public Task<DefaultIdentityModel> GetMockDefaultIdentity(DefaultIdentityModel e)
        {
            throw new System.NotImplementedException();
        }
    }
}
