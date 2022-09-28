using ExploringSelfSovereignIdentityAPI.Commands.Auth;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services.Auth
{
    public interface IAuthService
    {

        Task<string> Authenticate(AuthCommand request);
    }
}
