using ExploringSelfSovereignIdentityAPI.Models.Entity;
using Nethereum.ABI.FunctionEncoding.Attributes;
using System.Numerics;

namespace ExploringSelfSovereignIdentityAPI.Models.Request
{
    public partial class AttributeUpdate : AttributeUpdateBase { }

    public class AttributeUpdateBase
    {
        [Parameter("tuple", "attribute", 1)]
        public virtual Attribute Attribute { get; set; }
        [Parameter("int256", "index", 2)]
        public virtual BigInteger Index { get; set; }
    }
}
