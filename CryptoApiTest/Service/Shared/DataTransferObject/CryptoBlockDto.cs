namespace Shared.DataTransferObject
{
    public record CryptoBlockDto
    {
        public long Id { get; init; }
        public string Hash { get; init; }
        public long? Height { get; init; }
        public string? Chain { get; init; }
        public string? Total { get; init; }
        public long? Fees { get; init; }
        public long? BaseFee { get; init; }
        public long? Size { get; init; }
        public int? Ver { get; init; }
        public DateTime? Time { get; init; }
        public DateTime? ReceivedTime { get; init; }
        public string? CoinbaseAddr { get; init; }
        public string? RelayedBy { get; init; }
        public int? Nonce { get; init; }
        public int? NTx { get; init; }
        public string? PrevBlock { get; init; }
        public string? MrklRoot { get; init; }
        public List<string>? Txids { get; init; }
        public List<string>? InternalTxids { get; init; }
        public int? Depth { get; init; }
        public string? PrevBlockUrl { get; init; }
        public string? TxUrl { get; init; }
        public string? NextTxids { get;  init; }
    }
}
