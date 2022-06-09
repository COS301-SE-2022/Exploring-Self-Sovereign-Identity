using ExploringSelfSovereignIdentityAPI.Models.Entity;
using ExploringSelfSovereignIdentityAPI.Models.Request;
using MediatR;
using System;

namespace ExploringSelfSovereignIdentityAPI.Commands.Transactions
{
    public class SaveTransactionCommand : IRequest<Transaction>
    {
        public Guid To { get; set; }
        public Guid From { get; set; }
        public AddContractRequest contract { get; set; }

        public SaveTransactionCommand()
        {

        }
    }
}
