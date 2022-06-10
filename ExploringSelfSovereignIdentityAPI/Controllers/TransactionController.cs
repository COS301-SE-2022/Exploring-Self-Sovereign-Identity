using ExploringSelfSovereignIdentityAPI.Commands.Contract;
using ExploringSelfSovereignIdentityAPI.Commands.Transactions;
using ExploringSelfSovereignIdentityAPI.Models.Entity;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using ExploringSelfSovereignIdentityAPI.Queries.Example;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


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


        
        [HttpPost("addPendingTransaction")]
        public async Task<Transaction> AddPendingTransaction([FromBody] AddTransactionCommand pendingTransaction)
        {
            return await mediator.Send(pendingTransaction);

        }


        [HttpPost("getPendingTransaction")]
        public async Task<List<Transaction>> FetchPendingTransaction([FromBody] GetPendingTransactionQuery query)
        {
            
            return await mediator.Send(query);

        }

        [HttpPost("getPastTransaction")]
        public async Task<List<Transaction>> FetchPastTransaction([FromBody] GetPastTransactionQuery query)
        {
            return await mediator.Send(query);

        }





        [HttpPost("contract")]
        public async Task<GetContractResponse> addContract([FromBody] AddContractCommand command)
        {
            return await mediator.Send(command);
        }
        


    }
}
