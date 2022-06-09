using ExploringSelfSovereignIdentityAPI.Commands.Contract;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using ExploringSelfSovereignIdentityAPI.Queries.Example;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Transactions;

namespace ExploringSelfSovereignIdentityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly IMediator mediator;

        public TransactionController(IMediator med)
        {
            mediator = med;
        }
        /*
         [HttpGet("getExamples")]
        public async Task<string> GetExample()
        {
            return await mediator.Send(new ExampleGetQuery());
        }*/


        /*
        [HttpGet("getExamples")]
        public async Task<Transaction> AddPendingTransaction()
        {
            //return await mediator.Send(new GetPendingTransactionQuery());
            
        }*/

  



        [HttpPost("contract")]
        public async Task<GetContractResponse> addContract([FromBody] AddContractCommand command)
        {
            return await mediator.Send(command);
        }
        


    }
}
