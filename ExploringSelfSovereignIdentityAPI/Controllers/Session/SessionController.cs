using ExploringSelfSovereignIdentityAPI.Models.Request;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using ExploringSelfSovereignIdentityAPI.Services;
using ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Controllers.Session
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : Controller
    {
        private ISessionService sessionService;

        public SessionController(ISessionService service)
        {
            this.sessionService = service;
        }

        [HttpPost]
        [Route("issue")]
        public async Task<OtpConnectResponse> issue([FromBody] IssueCredentialRequest request)
        {
            return await sessionService.issue(request.id, request.credential);
        }

        [HttpPost]
        [Route("initialize")]
        public OtpResponse initialize()
        {
            return sessionService.initializeSession();
        }

        [HttpPost]
        [Route("connect")]
        public OtpConnectResponse connect([FromBody] ConnectRequest request)
        {
            return sessionService.connect(request.otp, request.credential);
        }

        [HttpPost]
        [Route("finish")]
        public CredentialResponseBase finish([FromBody] FinishRequest request)
        {
            return sessionService.finish(request.otp);
        }
    }
}
