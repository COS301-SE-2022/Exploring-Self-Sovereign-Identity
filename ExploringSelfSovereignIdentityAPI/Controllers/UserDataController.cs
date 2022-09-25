using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using ExploringSelfSovereignIdentityAPI.Models.Entity;
using ExploringSelfSovereignIdentityAPI.Queries;
using MediatR;
using ExploringSelfSovereignIdentityAPI.Commands;

namespace ExploringSelfSovereignIdentityAPI.Controllers.UserData
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : Controller
    {

        private readonly IMediator mediator;

        private UserDataResponse response = new UserDataResponse();

        public UserDataController(IMediator med)
        {
            this.mediator = med;
        }

        [HttpPost]
        [Route("create")]
        public async Task<string> Register([FromBody] CreateRequestCommand request)
        {
            return await mediator.Send(request);
        }

        [HttpPost]
        [Route("get")]
        public async Task<GetUserDataOutputDTO> GetUserData([FromBody] RegisterRequest request)
        {
            return await mediator.Send(request);

        }

        [HttpPost]
        [Route("updateAttribute")]
        public async Task<UserDataResponse> UpdateAttributesAsync([FromBody] UserDataResponse request)
        {

            return await mediator.Send(request);

                    
        }

        [HttpPost]
        [Route("updateCredential")]
        public async Task<GetUserDataOutputDTO> UpdateCredentials([FromBody] UpdateGen2 request )
        {
            return await mediator.Send(request);
        }

        //Transactions

        [HttpPost]
        [Route("newTransaction")]
        public async Task<string> newTransaction([FromBody] TransactionRequest request)
        {
            return await mediator.Send(request);
        }
    }
}
