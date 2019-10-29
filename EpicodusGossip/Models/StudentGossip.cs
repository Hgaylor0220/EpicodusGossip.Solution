namespace EpicodusGossip.Models
{
    public class StudentGossip
    {
        public int StudentGossiptId { get; set; }
        public int StudentId { get; set; }
        public int GossipId { get; set; }
        public Student Student { get; set; }
        public Gossip Gossip { get; set; }

    }
}