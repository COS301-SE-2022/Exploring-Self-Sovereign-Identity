using ExploringSelfSovereignIdentityAPI.Commands.Example;
using ExploringSelfSovereignIdentityAPI.Models.Example;
using ExploringSelfSovereignIdentityAPI.Queries.Example;
using ExploringSelfSovereignIdentityAPI.Services.blockChain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Controllers.Example
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExampleController : Controller
    {
        private readonly IMediator mediator;

        private readonly IBlockchainService blockchainService;

        public ExampleController(IMediator med, IBlockchainService blockchainService)
        {
            mediator = med;
            this.blockchainService = blockchainService;
        }

        [HttpGet("getExamples")]
        public async Task<string> GetExample()
        {
            return await mediator.Send(new ExampleGetQuery());
        }

        [HttpPost("addExamples")]
        public async Task<ExampleModel> AddExample([FromBody] ExampleAddCommand command)
        {
            return await mediator.Send(command);
        }

        [HttpGet("testBlockchainCreateUser")]
        public async Task<string>  crceateUser()
        {
            return await blockchainService.createUser("");
        }
    }
}
