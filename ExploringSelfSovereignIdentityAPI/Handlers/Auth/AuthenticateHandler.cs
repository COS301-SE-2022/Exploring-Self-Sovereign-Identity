using ExploringSelfSovereignIdentityAPI.Commands.Auth;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using ExploringSelfSovereignIdentityAPI.Services.Auth;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Handlers.Auth
{
    public class AuthenticateHandler : IRequestHandler<AuthenticateCommand, AuthenticateResponse>
    {
        private readonly IAuthService _service;

        public AuthenticateHandler(IAuthService service)
        {
            _service = service;
        }
        public async Task<AuthenticateResponse> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {

            return await _service.Authenticate(request);
        }
    }
}
