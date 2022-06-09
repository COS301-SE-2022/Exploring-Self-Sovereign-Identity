using ExploringSelfSovereignIdentityAPI.Models.Entity;

namespace ExploringSelfSovereignIdentityAPI.Models.Response
{
    public class TransactionResponse
    {
        public string From { get; set; }
        public string To { get; set; }

        public GetContractResponse contract { get; set; }
    }
}
