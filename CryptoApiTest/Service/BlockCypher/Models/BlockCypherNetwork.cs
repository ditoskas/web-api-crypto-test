namespace BlockCypher.Models
{
    public class BlockCypherNetwork
    {
        public string Name { get; set; }
        public long Height { get; set; }
        public string Hash { get; set; }
        public DateTime Time { get; set; }
        public string? LatestUrl { get; set; }
        public string? PreviousHash { get; set; }
        public string? PreviousUrl { get; set; }
        public string? PeerCount { get; set; }
        public string? UnconfirmedCount { get; set; }
        public long HighGasPrice { get; set; }
        public long MediumGasPrice { get; set; }
        public long LowGasPrice { get; set; }
        public long HighPriorityFee { get; set; }
        public long MediumPriorityFee { get; set; }
        public long LowPriorityFee { get; set; }
        public long BaseFee { get; set; }
        public string? LastForkHeight { get; set; }
        public string? LastForkHash { get; set; }
    }
}
