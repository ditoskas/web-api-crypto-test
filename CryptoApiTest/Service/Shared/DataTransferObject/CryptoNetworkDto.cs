﻿namespace Shared.DataTransferObject
{
    public record CryptoNetworkDto
    {
        public long Id { get; init; }
        public string? Name { get; init; }
        public string? Description { get; init; }
        public string? Symbol { get; init; }
    }
}
