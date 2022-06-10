using ExploringSelfSovereignIdentityAPI.Queries.Example;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using ExploringSelfSovereignIdentityAPI.Models.Entity;
using System.Threading.Tasks;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using ExploringSelfSovereignIdentityAPI.Services.Transactions;
using ExploringSelfSovereignIdentityAPI.Commands.Transactions;

namespace ExploringSelfSovereignIdentityAPI.Handlers.TransactionHandlers
{
    public class GetPendingTransactionsHandler : 
        IRequestHandler<GetPendingTransactionQuery, List<GetTransactionResponse>>,
        IRequestHandler<AddTransactionCommand, Transaction>
    {

        private readonly ITransactionService _service;
        public GetPendingTransactionsHandler(ITransactionService service)
        {
            _service = service;
        }

        public async Task<List<GetTransactionResponse>> Handle(GetPendingTransactionQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetPendingTransactions(request.Id);
        }

        public async Task<Transaction> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
        {
            return await _service.AddPendingTransaction(request);
        }
    }
}
