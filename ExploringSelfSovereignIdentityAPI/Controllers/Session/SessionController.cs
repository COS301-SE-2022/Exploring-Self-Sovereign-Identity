using ExploringSelfSovereignIdentityAPI.Commands.SessionCommand;
using ExploringSelfSovereignIdentityAPI.Models.Default;
using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
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
