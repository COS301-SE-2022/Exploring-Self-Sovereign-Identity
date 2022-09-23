using ExploringSelfSovereignIdentityAPI.Models.Entity;
using Nethereum.ABI.FunctionEncoding.Attributes;
using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Models.Response
{
    public partial class GetAttributesTransactionOutputDTO : GetAttributesTransactionOutputDTOBase { }

    [FunctionOutput]
    public class GetAttributesTransactionOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("tuple[]", "", 1)]
        public virtual List<Attribute> ReturnValue1 { get; set; }
    }
}
