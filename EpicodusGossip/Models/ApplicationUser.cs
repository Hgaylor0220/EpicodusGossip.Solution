
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EpicodusGossip.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Gossips = new HashSet<Gossip>();
        }
        public int ApplicationUserId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Gossip> Gossips { get; set; }
        
    }
}