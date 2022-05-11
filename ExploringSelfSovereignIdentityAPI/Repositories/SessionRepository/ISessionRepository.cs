using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Repositories.SessionRepository
{
    public interface ISessionRepository
    {
        Task<DefaultIdentityModel> GetMockDefaultIdentity(DefaultIdentityModel e);

        Task<DefaultIdentityResponse> confirmIdentity(DefaultIdentityModel e);
    }
}
