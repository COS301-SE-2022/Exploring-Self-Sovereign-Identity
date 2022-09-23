using ExploringSelfSovereignIdentityAPI.Models.Request;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace ExploringSelfSovereignIdentityAPI.Models.Function
{
    public partial class NewTransactionRequestFunction : NewTransactionRequestFunctionBase { }

    [Function("newTransactionRequest")]
    public class NewTransactionRequestFunctionBase : FunctionMessage
    {
        [Parameter("tuple", "request", 1)]
        public virtual TransactionRequest Request { get; set; }
    }
}
