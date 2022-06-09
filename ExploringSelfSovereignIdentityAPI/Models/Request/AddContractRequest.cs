using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Models.Request
{
    public class AddContractRequest
    {
        public string Signature { get; set; }

        public LinkedList<AddAttributeRequest> Attributes { get; set; }

        public AddContractRequest()
        {
            Attributes = new LinkedList<AddAttributeRequest>();
        }
    }
}
