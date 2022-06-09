using ExploringSelfSovereignIdentityAPI.Models.Entity;
using MediatR;
using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Queries.Example
{
    public class GetPendingTransactionQuery:IRequest<List<Transaction>>
    {

    }


}
