using ExploringSelfSovereignIdentityAPI.Models.Response;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace ExploringSelfSovereignIdentityAPI.Models.Function
{
    public partial class GetUserDataFunction : GetUserDataFunctionBase { }

    [Function("getUserData", typeof(GetUserDataOutputDTO))]
    public class GetUserDataFunctionBase : FunctionMessage
    {
        [Parameter("string", "_id", 1)]
        public virtual string Id { get; set; }
    }
}
