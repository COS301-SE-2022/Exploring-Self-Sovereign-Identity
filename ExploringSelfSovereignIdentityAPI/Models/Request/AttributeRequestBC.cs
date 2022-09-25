using ExploringSelfSovereignIdentityAPI.Models.Entity;
using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Models.Request
{
    public class AttributeRequestBC
    {
        public string id { get; set; }
        public List<AttributeBC> attributes { get; set; }

        public AttributeRequestBC()
        {
            attributes = new List<AttributeBC>();
        }
    }
}
