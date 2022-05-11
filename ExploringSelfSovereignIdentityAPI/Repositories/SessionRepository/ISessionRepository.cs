using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Repositories.SessionRepository
{
    public interface ISessionRepository
    {
        Task<DefaultIdentityModel> GetMockDefaultIdentity(DefaultIdentityModel e);
    }
}
