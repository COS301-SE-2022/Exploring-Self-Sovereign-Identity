using ExploringSelfSovereignIdentityAPI.Models.Entity;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Models.Function
{
    public partial class GetAttributesTransactionFunction : GetAttributesTransactionFunctionBase { }

    [Function("getAttributesTransaction", typeof(GetAttributesTransactionOutputDTO))]
    public class GetAttributesTransactionFunctionBase : FunctionMessage
    {
        [Parameter("string", "_id", 1)]
        public virtual string Id { get; set; }
        [Parameter("tuple[]", "attributes", 2)]
        public virtual List<Attribute> Attributes { get; set; }
    }
}
