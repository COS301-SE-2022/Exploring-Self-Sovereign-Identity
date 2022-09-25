using ExploringSelfSovereignIdentityAPI.Models.Entity;
using Nethereum.ABI.FunctionEncoding.Attributes;
using System.Collections.Generic;
using System.Numerics;

namespace ExploringSelfSovereignIdentityAPI.Models.Request
{
    public partial class CredentialUpdate : CredentialUpdateBase { }

    public class CredentialUpdateBase
    {
        [Parameter("string", "organization", 1)]
        public virtual string Organization { get; set; }
        [Parameter("int256", "index", 2)]
        public virtual BigInteger Index { get; set; }
        [Parameter("tuple[]", "attributes", 3)]
        public virtual List<Attribute> Attributes { get; set; }

        public CredentialUpdateBase()
        {
            Attributes = new List<Attribute>();
        }
    }
}
