using System;

namespace ExploringSelfSovereignIdentityAPI.Models.Entity
{
    public class OrganizationCredentials
    {
        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; }

        public Guid AttributeId { get; set; }
    }
}
