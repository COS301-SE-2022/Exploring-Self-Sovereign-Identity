using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Models.Entity
{
    public class CredentialBC
    {
        public string organization { get; set; }
        public List<AttributeBC> attributes { get; set; }

        public CredentialBC()
        {
            attributes = new List<AttributeBC>();
        }
    }
}
