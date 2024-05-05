using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace Api2.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string DbPath = System.IO.Path.Join(path, "cryptos.db");

            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlite($"Data Source={DbPath}",
                b => b.MigrationsAssembly("Api"));

            return new RepositoryContext(builder.Options);
        }

        public static string GetDbPath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return System.IO.Path.Join(path, "cryptos.db");
        }

        public static string GetConnectionString()
        {
            return $"Data Source={GetDbPath()}";
        }
    }
}
