using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CryptoRepository : RepositoryBase<Crypto>, ICryptoRepository
    {
        public CryptoRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<IEnumerable<Crypto>> GetAllCryptosAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<Crypto?> GetCryptoAsync(long id, bool trackChanges) => await FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void CreateCrypto(Crypto crypto) => Create(crypto);

        public void UpdateCrypto(Crypto crypto) => Update(crypto);

        public void DeleteCrypto(Crypto crypto) => Delete(crypto);
    }
}
