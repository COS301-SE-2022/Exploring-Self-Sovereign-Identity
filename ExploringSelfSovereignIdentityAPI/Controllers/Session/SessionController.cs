using ExploringSelfSovereignIdentityAPI.Commands.Example;
using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
using ExploringSelfSovereignIdentityAPI.Models.Example;
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
        public IActionResult init()
        {
            //return otp

            return Ok();
        }

        [HttpPost("connect")]
        public async Task<IActionResult> validateOTP() 
        {
            //Accept the OTP
            //Return the required set of fields
            //return await mediator.Send(new );
            //Should redirect to the page where they have to check/select the fields the Holder wants to expose

           return Ok();
        }

        [HttpPost("confirm")]
        public IActionResult confirm()
        {
            //Receive the selected fields  to expose
            //Finalise the identity creation
            //Return the fileds to expose and a token

            return Ok();
        }


    }
}
