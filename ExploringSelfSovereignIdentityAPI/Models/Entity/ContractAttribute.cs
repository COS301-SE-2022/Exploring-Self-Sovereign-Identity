using System;
using System.ComponentModel.DataAnnotations;

//! ContractAttribute Class 
/*
    Declared ContractAttribute class
    @author Rebecca Pillay
 
*/

namespace ExploringSelfSovereignIdentityAPI.Models.Entity
{
    //! ContractAttribute to hold attributes of contract
    /*
        Id - User Id associated with Contract Attributes
        ContractId - Id associated with specific contract 
        AttributeId - Id associated with attributes of current contract

    */
    public class ContractAttribute
    {
        public Guid Id { get; set; }

        [Encrypted]
        public Guid ContractId { get; set; }


        [Encrypted]
        public Guid attributeId { get; set; }

        public ContractAttribute()
        {

        }
        public ContractAttribute(Guid Id, Guid ContractId, Guid attributeId)
        {
            this.Id = Id;
            this.ContractId = ContractId;
            this.attributeId = attributeId;
        }
    }
}
