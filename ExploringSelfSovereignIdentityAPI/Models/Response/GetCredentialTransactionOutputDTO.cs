using Nethereum.ABI.FunctionEncoding.Attributes;

namespace ExploringSelfSovereignIdentityAPI.Models.Response
{
    public partial class GetCredentialTransactionOutputDTO : GetCredentialTransactionOutputDTOBase { }

    [FunctionOutput]
    public class GetCredentialTransactionOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("tuple", "", 1)]
        public virtual CredentialResponse ReturnValue1 { get; set; }
    }
}
