using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CryptoRepository : RepositoryBase<Crypto>, ICryptoRepository
    {
        public CryptoRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        /// <summary>
        /// Get all crypto records
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Crypto>> GetAllCryptosAsync(bool trackChanges) => await FindAll(trackChanges).ToListAsync();
        /// <summary>
        /// Get a crypto record by its id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<Crypto?> GetCryptoAsync(long id, bool trackChanges) => await FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        /// <summary>
        /// Get a crypto network by its symbol
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="chain"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<Crypto?> GetCryptoWithNetworkAsync(string symbol, string chain, bool trackChanges)
        {
            return await FindByCondition(c => c.Symbol.Equals(symbol), trackChanges)
                                .Include(cn => cn.CryptoNetworks.Where(cn => cn.Name == chain))
                                .SingleOrDefaultAsync();
        }
        /// <summary>
        /// Create a new Crypto record
        /// </summary>
        /// <param name="crypto"></param>
        public void CreateCrypto(Crypto crypto) => Create(crypto);
        /// <summary>
        /// Update a Crypto record
        /// </summary>
        /// <param name="crypto"></param>
        public void UpdateCrypto(Crypto crypto) => Update(crypto);
        /// <summary>
        /// Delete a Crypto record
        /// </summary>
        /// <param name="crypto"></param>
        public void DeleteCrypto(Crypto crypto) => Delete(crypto);
    }
}
