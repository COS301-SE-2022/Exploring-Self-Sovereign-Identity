using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Models
{
    public class CredentialBC
    {
        public string organization { get; set; }
        public AttributeBC[] attributes { get; set; }
    }
}
