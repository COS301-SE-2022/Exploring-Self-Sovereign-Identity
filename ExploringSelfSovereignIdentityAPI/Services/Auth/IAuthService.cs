using ExploringSelfSovereignIdentityAPI.Commands.Auth;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services.Auth
{
    public interface IAuthService
    {

        Task<AuthenticateResponse> Authenticate(AuthCommand request);
    }
}
