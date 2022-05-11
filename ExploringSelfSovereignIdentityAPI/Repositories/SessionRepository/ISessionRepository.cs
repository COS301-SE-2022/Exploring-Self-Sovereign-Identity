using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Repositories.SessionRepository
{
    public interface ISessionRepository
    {
        Task<DefaultIdentityModel> Add(DefaultIdentityModel e);
        Task<DefaultIdentityModel> Update(DefaultIdentityModel e);
    }
}
