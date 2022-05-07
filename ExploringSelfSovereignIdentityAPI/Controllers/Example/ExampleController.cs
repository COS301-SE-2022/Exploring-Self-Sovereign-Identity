using ExploringSelfSovereignIdentityAPI.Queries.Example;
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

        public ExampleController(IMediator med)
        {
            mediator = med;
        }

        [HttpGet("getExamples")]
        public async Task<string> GetExample()
        {
            return await mediator.Send(new ExampleGetQuery());
        }

        [HttpPost("addExamples")]
        public async Task<OkResult> AddExample()
        {
            return Ok();
        }
    }
}
