using ExploringSelfSovereignIdentityAPI.Commands.SessionCommand;
using ExploringSelfSovereignIdentityAPI.Models.Default;
using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Controllers.Session
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : Controller
    {
        private readonly IMediator mediator;

        public SessionController(IMediator med)
        {
            mediator = med;
        }

        [HttpPost("init")]
        public async Task<OtpResponse> Init()
        {
            return  await mediator.Send(new OtpResponseCommand());
        }

        [HttpPost("connect")]
        public async Task<DefaultIdentityModel> validateOTP([FromBody] GetDefaultSessionCommand sessionCommand)
        {
            DefaultSessionModel isSession = await mediator.Send(sessionCommand);

            if (isSession == null)
                return null;

            GetDefaultIdentityCommand identityCommand = new GetDefaultIdentityCommand();
            return await mediator.Send(identityCommand);
        }

        [HttpPost("confirm")]
        public async Task<DefaultIdentityResponse> confirm([FromBody] ConfirmIdentityCommand command)
        {
            return await mediator.Send(command);

        }


    }
}
