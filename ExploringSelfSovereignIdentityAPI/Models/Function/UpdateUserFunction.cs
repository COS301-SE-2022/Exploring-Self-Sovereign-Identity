using ExploringSelfSovereignIdentityAPI.Models.Request;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace ExploringSelfSovereignIdentityAPI.Models.Function
{
    public partial class UpdateUserFunction : UpdateUserFunctionBase { }

    [Function("updateUser")]
    public class UpdateUserFunctionBase : FunctionMessage
    {
        [Parameter("tuple", "update", 1)]
        public virtual Update Update { get; set; }
    }
}
