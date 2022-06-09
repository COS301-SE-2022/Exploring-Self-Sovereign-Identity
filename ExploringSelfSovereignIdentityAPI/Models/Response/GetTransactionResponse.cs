using System;

namespace ExploringSelfSovereignIdentityAPI.Models.Response
{
    public class GetTransactionResponse
    {
        public Guid Id { get; set; }
        public Guid To { get; set; }
        public Guid From { get; set; }

        public GetContractResponse contract { get; set; } 

        public GetTransactionResponse()
        {
            contract = new GetContractResponse();
        }
    }
}
