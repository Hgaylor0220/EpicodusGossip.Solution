using System.Collections.Generic;

namespace EpicodusGossip.Models
{
    public class Gossip
    {
        public Gossip()
        {
            this.Students = new HashSet<StudentGossip>();
        }

        public int GossipId { get; set; }
        public string GossipTitle { get; set; }
        public string GossipContent {get; set;}
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<StudentGossip> Students { get; set; }

    }
}