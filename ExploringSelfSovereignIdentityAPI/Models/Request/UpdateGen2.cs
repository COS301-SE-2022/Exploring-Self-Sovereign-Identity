using Nethereum.ABI.FunctionEncoding.Attributes;
using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Models.Request
{
    public partial class UpdateGen2 : UpdateBaseGen2 { }

    public class UpdateBaseGen2
    {
        [Parameter("string", "id", 1)]
        public virtual string Id { get; set; }
        [Parameter("tuple[]", "attributes", 2)]
        public virtual List<AttributeUpdateGen2> Attributes { get; set; }
        [Parameter("tuple[]", "credentials", 3)]
        public virtual List<CredentialUpdateGen2> Credentials { get; set; }
    }
}
