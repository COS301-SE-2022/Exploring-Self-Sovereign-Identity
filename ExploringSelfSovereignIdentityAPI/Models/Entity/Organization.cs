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

        public Organization()
        {

        }
        public Organization(Guid Id, string Name, string hash)
        {
            this.Id = Id;
            this.Name = Name;
            this.hash = hash;
        }
    }
}
