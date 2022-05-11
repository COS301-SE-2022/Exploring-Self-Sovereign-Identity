using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services
{
    public interface ISessionService
    {
        Task<DefaultIdentityModel> GetMockDefaultIdentity(DefaultIdentityModel e);
    }
}
