using ExploringSelfSovereignIdentityAPI.Models.Request;
using System;
using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Models.Response
{
    public class GetContractResponse
    {

        public string Signature { get; set; }
        public Guid Id { get; set; }

        public LinkedList<AddAttributeRequest> Attributes { get; set; }

        public GetContractResponse()
        {
            Attributes = new LinkedList<AddAttributeRequest>();
        }

    }
}


