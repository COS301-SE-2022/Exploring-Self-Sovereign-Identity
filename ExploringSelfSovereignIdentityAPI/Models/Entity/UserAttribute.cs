using System;

namespace ExploringSelfSovereignIdentityAPI.Models.Entity
{
    public class UserAttribute
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public Guid AttributeID { get; set; }
    }
}
