using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class CryptoConfiguration : IEntityTypeConfiguration<Crypto>
    {
        public void Configure(EntityTypeBuilder<Crypto> builder)
        {
            builder.HasData
            (
                new Crypto
                {
                    Id = 1,
                    Symbol = "BTC",
                    Description = "Bitcoin",
                    CreatedAt = DateTime.UtcNow
                },
                new Crypto
                {
                    Id = 2,
                    Symbol = "ETH",
                    Description = "Ethereum",
                    CreatedAt = DateTime.UtcNow
                },
                new Crypto
                {
                    Id = 3,
                    Symbol = "LTC",
                    Description = "Litecoin",
                    CreatedAt = DateTime.UtcNow
                },
                new Crypto
                {
                    Id = 4,
                    Symbol = "Dash",
                    Description = "Dash",
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
