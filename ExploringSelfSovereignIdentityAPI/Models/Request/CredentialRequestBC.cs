using ExploringSelfSovereignIdentityAPI.Models.Entity;
using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Models.Request
{
    public class CredentialRequestBC
    {
        public string id { get; set; }
        public List<CredentialBC> credentials { get; set; }

        public CredentialRequestBC()
        {
            credentials = new List<CredentialBC>();
        }
    }
}
