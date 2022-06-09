using System;

//! OrganizationCredentials Class 
/*
    Declared OrganizationCredentials class
    @author Rebecca Pillay
 
*/
namespace ExploringSelfSovereignIdentityAPI.Models.Entity
{
    //! Class for credentials associated to Organizations 
    /*
        Id - Id associated with Organization attribute
        OrganizationId - Specifically generated Id associated with an organization 
        AttributeId - Id associated with each attribute of Organization credentials 

    */
    public class OrganizationCredentials
    {
        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; }

        public Guid AttributeId { get; set; }  

        public Guid Key { get; set; }

        public Guid Value { get; set; }
        
        /*
         * Changes:
         UserID
        OrgannizationID
        Key
        Value
         */
        public OrganizationCredentials()
        {

        }
        public OrganizationCredentials(Guid id, Guid OrganizationId, Guid AttributeId, Guid Key, Guid Value)
        {
            this.Id = id;
            this.OrganizationId = OrganizationId;
            this.AttributeId = AttributeId;
            this.Key = Key;
            this.Value = Value;
        }
            
    }
}
