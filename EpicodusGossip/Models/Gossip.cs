using System.Collections.Generic;

namespace EpicodusGossip.Models
{
    public class Gossip
    {

        public int GossipId { get; set; }
        public string GossipTitle { get; set; }
        public string GossipContent {get; set;}
        public int ApplicationUserId { get; set; }


    }
}