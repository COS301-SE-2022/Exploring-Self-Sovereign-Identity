using ExploringSelfSovereignIdentityAPI.Models.Response;
using MediatR;

namespace ExploringSelfSovereignIdentityAPI.Commands.Auth
{
    public class AuthenticateCommand : IRequest<AuthenticateResponse>
    {
        public string userId { get; set; }

        public string apiKey { get; set; }
    }
}
