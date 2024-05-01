namespace Shared.DataTransferObject
{
    public record CryptoDto
    {
        public long Id { get; init; }
        public string Symbol { get; init; }
        public string? Description { get; init; }
    }
}
