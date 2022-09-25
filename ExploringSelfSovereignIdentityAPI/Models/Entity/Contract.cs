using System;

//! Contract Class
/*
    Declared Contract class 
    @author Rebecca Pillay
 
*/

namespace ExploringSelfSovereignIdentityAPI.Models.Entity
{
    public class Contract
    {
        //! Transaction Contract between User and Organization 
        /*
            Id - User Id associated with transaction
            Signature - User signature used to initiate and authenticate transaction 

        */
        public Guid Id { get; set; }
        public string Signature { get; set; }

        //public Boolean granted { get; set; }

        /*
         Created when a contract is sent from the front-end
        This action also creates the transaction
         */

        public Contract(Guid Id, string Signature, Boolean granted)
        {
            this.Id = Id;
            this.Signature = Signature;
            //this.granted = granted;
        }
    }
}
