using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
        }


        public DbSet<Crypto>? Cryptos { get; set; }

    }
}
