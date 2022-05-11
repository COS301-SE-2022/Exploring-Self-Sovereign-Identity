using ExploringSelfSovereignIdentityAPI.Commands.Example;
using ExploringSelfSovereignIdentityAPI.Commands.SessionCommand;
using ExploringSelfSovereignIdentityAPI.Models.Default;
using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
using ExploringSelfSovereignIdentityAPI.Models.Example;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using ExploringSelfSovereignIdentityAPI.Queries.ConnectEndpoint;
using ExploringSelfSovereignIdentityAPI.Queries.Example;
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
            //return otp

            return  await mediator.Send(new OtpResponseCommand());

        }

        [HttpPost("connect")]
        public async Task<DefaultIdentityModel> validateOTP([FromBody] GetDefaultSessionCommand sessionCommand)
        {
            //Accept the OTP
            DefaultSessionModel isSession = await mediator.Send(sessionCommand);

            if (isSession == null)
                return null;

            //Return the required set of fields
            GetDefaultIdentityCommand identityCommand = new GetDefaultIdentityCommand();
            return await mediator.Send(identityCommand);
            //Should redirect to the page where they have to check/select the fields the Holder wants to expose

           //return Ok();
        }

        [HttpPost("confirm")]
        public async Task<DefaultIdentityResponse> confirm()
        {

            //Receive the selected fields  to expose
            //Finalise the identity creation
            //Return the fileds to expose and a token
            return await mediator.Send(new ConfirmIdentityCommand());

        }


    }
}
