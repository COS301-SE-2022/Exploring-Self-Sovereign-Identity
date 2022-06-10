using ExploringSelfSovereignIdentityAPI.Models.Entity;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Queries.Example
{ 

    public class GetPendingTransactionQuery:IRequest<List<GetTransactionResponse>>
    {
        public Guid Id { get; set; }

    }


}
