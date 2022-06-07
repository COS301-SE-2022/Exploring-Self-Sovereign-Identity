using System;
//! Organization Class 
/*
    Declared Organization class
    @author Rebecca Pillay
 
*/

namespace ExploringSelfSovereignIdentityAPI.Models.Entity
{
    //! Organization class that interacts with contract 
    /*
        Id - Id associated with transaction
        Name - Organization name 
        hash - Specific hash associated with Organization 
        
    */
    public class Organization
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
       
        public string hash { get; set; }
    }
}
