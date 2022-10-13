using ExploringSelfSovereignIdentityAPI.Commands.Auth;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IMediator mediator;
        public AuthController(IMediator med)
        {
            mediator = med;
        }

        [AllowAnonymous]

        [HttpPost("auth")]
        public async Task<AuthenticateResponse> AddExample([FromBody] AuthenticateCommand command)
        {
            return await mediator.Send(command);
        }
    }
}
