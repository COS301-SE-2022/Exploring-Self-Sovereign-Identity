using ExploringSelfSovereignIdentityAPI.Models.Entity;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace ExploringSelfSovereignIdentityAPI.Models.Request
{
    public partial class AttributeUpdateGen2 : AttributeUpdateBaseGen2 { }

    public class AttributeUpdateBaseGen2
    {
        [Parameter("tuple", "attribute", 1)]
        public virtual Attribute Attribute { get; set; }
        [Parameter("int256", "index", 2)]
        public virtual int Index { get; set; }

        public AttributeUpdateBaseGen2()
        {
            Attribute = new Attribute();
        }
    }
}
