using System;

//! UserAttribute Class 
/*
    Declared UserAttribute class
    @author Rebecca Pillay
 
*/

namespace ExploringSelfSovereignIdentityAPI.Models.Entity
{
    //! Class associated with User Attributes 
    /*
        Id - Id associated with UserAttribute table
        UserId - User Id that indentifies each user 
        AttributeId - Id associated with each user Attribute 
        granted - Boolean value associated with permission to allow/deny in information access 
        

    */
    public class UserAttribute
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public Guid AttributeID { get; set; }

        public UserAttribute()
        {

        }
        public UserAttribute(Guid Id, Guid UserId, Guid AttributeID)
        {
            this.Id = Id;
            this.UserId = UserId;
            this.AttributeID = AttributeID;
        }
    }
}
