using ExploringSelfSovereignIdentityAPI.Models.Entity;
using MediatR;
using System;
using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Queries.Example
{
    public class GetPastTransactionQuery : IRequest<List<Transaction>>
    {
        public Guid Id { get; set; }





    }
}
