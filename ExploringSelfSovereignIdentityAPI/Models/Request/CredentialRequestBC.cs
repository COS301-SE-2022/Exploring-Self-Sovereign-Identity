using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Models.Request
{
    public class CredentialRequestBC
    {
        public string id { get; set; }
        public CredentialBC[] credentials { get; set; }
    }
}
