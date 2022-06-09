using ExploringSelfSovereignIdentityAPI.Models.Entity;
using ExploringSelfSovereignIdentityAPI.Models.Request;
using MediatR;
using System;
using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Commands.Transactions
{
    public class AddTransactionCommand : IRequest<Transaction>
    {

        //public string signature { get; set; }
        public Guid To { get; set; }
        public Guid From { get; set; }
        public AddContractRequest contract { get; set; }

        public AddTransactionCommand()
        {
            
        }


    }
}
