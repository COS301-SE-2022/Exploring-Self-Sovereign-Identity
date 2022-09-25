using ExploringSelfSovereignIdentityAPI.Models.Entity;
using MediatR;
using Nethereum.ABI.FunctionEncoding.Attributes;
using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Commands
{
    public partial class TransactionRequest : TransactionRequestBase { }

    public class TransactionRequestBase : IRequest<string>
    {
        [Parameter("string[]", "attributes", 1)]
        public virtual List<string> Attributes { get; set; }
        [Parameter("tuple", "stamp", 2)]
        public virtual TransactionStamp Stamp { get; set; }

        public TransactionRequestBase()
        {
            Attributes = new List<string>();
            Stamp = new TransactionStamp();
        }
    }
}
