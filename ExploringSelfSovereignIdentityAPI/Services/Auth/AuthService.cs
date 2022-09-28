using ExploringSelfSovereignIdentityAPI.Commands.Auth;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
                throw new Exception("Invalid key");
            }

            AuthenticateResponse response = new AuthenticateResponse();

            response.token = generateToken(request.userId);

            return response;


        }

        private string generateToken(String userId)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audiance"],
                claims,
                expires: DateTime.Now.AddSeconds(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token); 
        }

        private bool isKeyValid(String key)
        {
            return key == _config["apiKey"];
        }
    }
}
