using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

//! Attribute Class
/*
    Declared Attribute class for User Attribute table
    @author Rebecca Pillay
 
*/

namespace ExploringSelfSovereignIdentityAPI.Models.Entity
{
    public partial class Attribute : AttributeBase { }

    public class AttributeBase
    {
        [Parameter("string", "name", 1)]
        public virtual string Name { get; set; }
        [Parameter("string", "value", 2)]
        public virtual string Value { get; set; }
    }
}
