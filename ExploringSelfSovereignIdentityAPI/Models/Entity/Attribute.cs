using System;

//! Attribute Class
/*
    Declared Attribute class for User Attribute table
    @author Rebecca Pillay
 
*/

namespace ExploringSelfSovereignIdentityAPI.Models.Entity
{
    public class Attribute
    {
        //! Attributes for User Data
        /*
            Id - User Id associated with attribute
            Name - Name of attribute
            Value - Value associated with Name attribute
         */
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
