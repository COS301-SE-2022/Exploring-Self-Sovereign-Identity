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
    }
}
