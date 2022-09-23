using Nethereum.ABI.FunctionEncoding.Attributes;

namespace ExploringSelfSovereignIdentityAPI.Models.Response
{
    public partial class GetUserDataOutputDTO : GetUserDataOutputDTOBase { }

    [FunctionOutput]
    public class GetUserDataOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("tuple", "", 1)]
        public virtual UserDataResponse ReturnValue1 { get; set; }
    }
}
