using ExploringSelfSovereignIdentityAPI.Commands.Auth;
using ExploringSelfSovereignIdentityAPI.Services.Auth;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Handlers.Auth
{
    public class AuthenticateHandler : IRequestHandler<AuthCommand, string>
    {
        private readonly IAuthService _service;

        public AuthenticateHandler(IAuthService service)
        {
            _service = service;
        }
        public async Task<string> Handle(AuthCommand request, CancellationToken cancellationToken)
        {

            return await _service.Authenticate(request);
        }
    }
}
