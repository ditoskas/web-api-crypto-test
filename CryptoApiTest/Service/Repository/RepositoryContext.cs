using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CryptoConfiguration());
            modelBuilder.ApplyConfiguration(new CryptoNetworkConfiguration());
        }


        public DbSet<Crypto>? Cryptos { get; set; }
        public DbSet<CryptoNetwork>? CryptoNetworks { get; set; }
        public DbSet<CryptoBlock>? CryptoBlocks { get; set; }
        public DbSet<CryptoTransaction>? CryptoTransactions { get; set; }
        public DbSet<CryptoInternalTransaction>? CryptoInternalTransactions { get; set; }

    }
}
