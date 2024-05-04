using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    /// <summary>
    /// Seed data for cryptonetworks table
    /// </summary>
    public class CryptoNetworkConfiguration : IEntityTypeConfiguration<CryptoNetwork>
    {
        public void Configure(EntityTypeBuilder<CryptoNetwork> builder)
        {
            builder.HasData
            (
                new CryptoNetwork
                {
                    Id = 1,
                    Name = "main",
                    Description = "Main network for BTC",
                    CryptoId = 1,
                    CreatedAt = DateTime.UtcNow
                },
                new CryptoNetwork
                {
                    Id = 2,
                    Name = "test3",
                    Description = "Test network for BTC",
                    CryptoId = 1,
                    CreatedAt = DateTime.UtcNow
                },
                new CryptoNetwork
                {
                    Id = 3,
                    Name = "main",
                    Description = "Main network for ETH",
                    CryptoId = 2,
                    CreatedAt = DateTime.UtcNow
                },
                new CryptoNetwork
                {
                    Id = 4,
                    Name = "main",
                    Description = "Main network for LTC",
                    CryptoId = 3,
                    CreatedAt = DateTime.UtcNow
                },
                new CryptoNetwork
                {
                    Id = 5,
                    Name = "main",
                    Description = "Main network for Dash",
                    CryptoId = 4,
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
