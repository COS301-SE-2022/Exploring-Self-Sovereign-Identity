using System;

namespace ExploringSelfSovereignIdentityAPI.Models.Entity
{
    public class Organization
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
       
        public string hash { get; set; }
    }
}
