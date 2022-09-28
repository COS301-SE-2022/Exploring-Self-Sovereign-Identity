using ExploringSelfSovereignIdentityAPI.Commands.Auth;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services.Auth
{
    public class AuthService : IAuthService
    {
        private IConfiguration _config;

        private IUserDataService _userDataService;
        public async Task<AuthenticateResponse> Authenticate(AuthenticateCommand request)
        {
            var user = _userDataService.getUserData(request.userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (!isKeyValid(request.apiKey))
            {
                throw new Exception("User not found");
            }

            return null;


        }

        private string generateToken(String userId)
        {
            return null;
        }

        private bool isKeyValid(String key)
        {
            return key == _config["apiKey"];
        }
    }
}
