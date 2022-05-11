using ExploringSelfSovereignIdentityAPI.Commands.SessionCommand;
using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
using ExploringSelfSovereignIdentityAPI.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Handlers.Session.ConnectEndpoint
{
    public class ConnectEndpointHandler : IRequestHandler<GetDefaultIdentityCommand, DefaultIdentityModel>
    {
        private readonly ISessionService _service;
        public ConnectEndpointHandler(ISessionService service)
        {
            _service = service
        }
        public Task<DefaultIdentityModel> Handle(GetDefaultIdentityCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
