using ExploringSelfSovereignIdentityAPI.Commands.SessionCommand;
using ExploringSelfSovereignIdentityAPI.Models.Default;
using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
using ExploringSelfSovereignIdentityAPI.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Handlers.Session.ConnectEndpoint
{
    public class ConnectEndpointHandler : 
        IRequestHandler<GetDefaultIdentityCommand, DefaultIdentityModel>, 
        IRequestHandler<GetDefaultSessionCommand, DefaultSessionModel>
    {
        private readonly ISessionService _service;
        public ConnectEndpointHandler(ISessionService service)
        {
            _service = service;
        }
        public async Task<DefaultIdentityModel> Handle(GetDefaultIdentityCommand request, CancellationToken cancellationToken)
        {
            return await _service.GetMockDefaultIdentity(new DefaultIdentityModel());
        }

        public async Task<DefaultSessionModel> Handle(GetDefaultSessionCommand request, CancellationToken cancellationToken)
        {
            
            DefaultSessionModel d = await _service.GetMockDefaultSession(new DefaultSessionModel());

            if (d.otp.Equals(request.otp))
                return d;
            return null;
        }
    }
}
