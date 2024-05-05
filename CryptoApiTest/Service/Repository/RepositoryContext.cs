using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository
{
    /// <summary>
    /// Represent the context of the database
    /// </summary>
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seed the database with the initial data
            modelBuilder.ApplyConfiguration(new CryptoConfiguration());
            modelBuilder.ApplyConfiguration(new CryptoNetworkConfiguration());
        }

        /// <summary>
        /// Represent the Cryptos table
        /// </summary>
        public DbSet<Crypto>? Cryptos { get; set; }
        /// <summary>
        /// Represent the CryptoNetworks table
        /// </summary>
        public DbSet<CryptoNetwork>? CryptoNetworks { get; set; }
        /// <summary>
        /// Represent the CryptoBlocks table
        /// </summary>
        public DbSet<CryptoBlock>? CryptoBlocks { get; set; }
        /// <summary>
        /// Represent the CryptoTransactions table
        /// </summary>
        public DbSet<CryptoTransaction>? CryptoTransactions { get; set; }
        /// <summary>
        /// Represent the CryptoInternalTransactions table
        /// </summary>
        public DbSet<CryptoInternalTransaction>? CryptoInternalTransactions { get; set; }

    }
}
