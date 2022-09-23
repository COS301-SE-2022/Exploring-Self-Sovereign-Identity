using ExploringSelfSovereignIdentityAPI.Models.Entity;
using Nethereum.ABI.FunctionEncoding.Attributes;
using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Models.Request
{
    public partial class CredentialUpdateGen2 : CredentialUpdateBaseGen2 { }

    public class CredentialUpdateBaseGen2
    {
        [Parameter("string", "organization", 1)]
        public virtual string Organization { get; set; }
        [Parameter("int256", "index", 2)]
        public virtual int Index { get; set; }
        [Parameter("tuple[]", "attributes", 3)]
        public virtual List<Attribute> Attributes { get; set; }
    }
}
