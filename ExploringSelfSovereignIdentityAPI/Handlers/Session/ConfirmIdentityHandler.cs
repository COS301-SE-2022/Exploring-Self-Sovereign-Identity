using ExploringSelfSovereignIdentityAPI.Commands.SessionCommand;
using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using ExploringSelfSovereignIdentityAPI.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Handlers.Session
{
    public class ConfirmIdentityHandler : IRequestHandler<ConfirmIdentityCommand, DefaultIdentityResponse>
    {
        private readonly ISessionService _service;
        public ConfirmIdentityHandler(ISessionService service)
        {
            _service = service;
        }

        public async Task<DefaultIdentityResponse> Handle(ConfirmIdentityCommand request, CancellationToken cancellationToken)
        {
            return await _service.confirmIdentity(new DefaultIdentityModel());
        }

    }
}
