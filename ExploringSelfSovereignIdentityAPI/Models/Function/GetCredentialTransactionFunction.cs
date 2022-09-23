using ExploringSelfSovereignIdentityAPI.Models.Response;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace ExploringSelfSovereignIdentityAPI.Models.Function
{
    public partial class GetCredentialTransactionFunction : GetCredentialTransactionFunctionBase { }

    [Function("getCredentialTransaction", typeof(GetCredentialTransactionOutputDTO))]
    public class GetCredentialTransactionFunctionBase : FunctionMessage
    {
        [Parameter("string", "_id", 1)]
        public virtual string Id { get; set; }
        [Parameter("string", "organization", 2)]
        public virtual string Organization { get; set; }
    }
}
