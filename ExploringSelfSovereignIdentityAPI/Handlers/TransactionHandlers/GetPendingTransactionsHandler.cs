using ExploringSelfSovereignIdentityAPI.Queries.Example;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using ExploringSelfSovereignIdentityAPI.Models.Entity;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Handlers.TransactionHandlers
{
    public class GetPendingTransactionsHandler : IRequestHandler<GetPendingTransactionQuery, List<Transaction>>
    {
        
        public Task<List<Transaction>> Handle(GetPendingTransactionQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
