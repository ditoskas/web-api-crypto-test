using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObject
{
    public record CryptoBlockForManipulationDto
    {
        public string Hash { get; set; }
        public long? Height { get; set; }
        public string Chain { get; set; }
        public string? Total { get; set; }
        public long? Fees { get; set; }
        public long? BaseFee { get; set; }
        public long? Size { get; set; }
        public int? Ver { get; set; }
        public DateTime? Time { get; set; }
        public DateTime? ReceivedTime { get; set; }
        public string? CoinbaseAddr { get; set; }
        public string? RelayedBy { get; set; }
        public int? Nonce { get; set; }
        public int? NTx { get; set; }
        public string? PrevBlock { get; set; }
        public string? MrklRoot { get; set; }
        public List<string> Txids { get; set; }
        public List<string> InternalTxids { get; set; }
        public int? Depth { get; set; }
        public string? PrevBlockUrl { get; set; }
        public string? TxUrl { get; set; }
        public string? NextTxids { get; set; }
    }
}
