using ExploringSelfSovereignIdentityAPI.Commands.Auth;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services.Auth
{
    public class AuthService : IAuthService
    {
        public async Task<AuthenticateResponse> Authenticate(AuthCommand request)
        {
            throw new System.NotImplementedException();
        }
    }
}
