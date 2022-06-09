using System;

namespace ExploringSelfSovereignIdentityAPI.Models.Entity
{
    public class Transaction
    {

        public Guid From { get; set; }
        public Guid To { get; set; }
        public Guid ContractID { get; set;}
         

        /*
         
         Mock encryption
        No Update functions
        retrieve historical transactions for user
        
         */
    }
}
