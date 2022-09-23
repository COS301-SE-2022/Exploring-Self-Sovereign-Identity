using Nethereum.ABI.FunctionEncoding.Attributes;
using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Models.Request
{
    public partial class Update : UpdateBase { }

    public class UpdateBase
    {
        [Parameter("string", "id", 1)]
        public virtual string Id { get; set; }
        [Parameter("tuple[]", "attributes", 2)]
        public virtual List<AttributeUpdate> Attributes { get; set; }
        [Parameter("tuple[]", "credentials", 3)]
        public virtual List<CredentialUpdate> Credentials { get; set; }
    }
}
