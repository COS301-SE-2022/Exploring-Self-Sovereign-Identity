using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace ExploringSelfSovereignIdentityAPI.Models.Function
{
    public partial class CreateUserFunction : CreateUserFunctionBase { }

    [Function("createUser")]
    public class CreateUserFunctionBase : FunctionMessage
    {
        [Parameter("string", "_id", 1)]
        public virtual string Id { get; set; }
    }
}
