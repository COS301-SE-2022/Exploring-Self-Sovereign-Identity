using ExploringSelfSovereignIdentityAPI.Commands.SessionCommand;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using ExploringSelfSovereignIdentityAPI.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Handlers.Session
{
    public class OtpResponseHandler : IRequestHandler<OtpResponseCommand, OtpResponse>
    {

        private readonly ISessionService _service;
        public OtpResponseHandler(ISessionService service)
        {
            _service = service;
        }
        public async Task<OtpResponse> Handle(OtpResponseCommand request, CancellationToken cancellationToken)
        {
            return await _service.GetOtpResponse(new OtpResponse());
        }
    }
}
