using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Models.Request
{
    public class AddContractRequest
    {
        public string Signature { get; set; }

        public List<AddAttributeRequest> Attributes { get; set; }

        public AddContractRequest()
        {
            Attributes = new List<AddAttributeRequest>();
        }
    }
}
