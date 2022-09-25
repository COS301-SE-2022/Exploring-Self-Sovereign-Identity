using ExploringSelfSovereignIdentityAPI.Models.Entity;
using Nethereum.ABI.FunctionEncoding.Attributes;
using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Models.Response
{
    public partial class TransactionResponse : TransactionResponseBase { }

    public class TransactionResponseBase
    {
        [Parameter("tuple[]", "attributes", 1)]
        public virtual List<Attribute> Attributes { get; set; }
        [Parameter("tuple", "stamp", 2)]
        public virtual TransactionStamp Stamp { get; set; }

        public TransactionResponseBase() 
        {
            Attributes = new List<Attribute>();
            Stamp = new TransactionStamp();
        }
    }
}
