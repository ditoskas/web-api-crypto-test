using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CryptoNetworkRepository : RepositoryBase<CryptoNetwork>, ICryptoNetworkRepository
    {
        public CryptoNetworkRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        /// <summary>
        /// Get all CryptoNetwork records
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CryptoNetwork>> GetAllCryptoNetworksAsync(bool trackChanges) => await FindAll(trackChanges).Include(cn => cn.Crypto).ToListAsync();
        /// <summary>
        /// Get crypto networks that belong to a specific crypto
        /// </summary>
        /// <param name="cryptoId"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CryptoNetwork>> GetCryptoNetworksAsync(long cryptoId, bool trackChanges)
        {
            return await FindByCondition(c => c.CryptoId.Equals(cryptoId), trackChanges).ToListAsync();
        }
        /// <summary>
        /// Get a CryptoNetwork record by its name and the symbol that it belongs to
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="chain"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<CryptoNetwork?> GetCryptoWithNetworkAsync(string symbol, string chain, bool trackChanges)
        {
            return await FindByCondition(cn => cn.Name.Equals(chain) && cn.Crypto.Symbol.Equals(symbol), trackChanges).SingleOrDefaultAsync();
        }
        /// <summary>
        /// Get a CryptoNetwork record by its id
        /// </summary>
        /// <param name="cryptoNetworkId"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<CryptoNetwork?> GetCryptoWithNetworkAsync(long cryptoNetworkId, bool trackChanges)
        {
            return await FindByCondition(cn => cn.Id.Equals(cryptoNetworkId), trackChanges).SingleOrDefaultAsync();
        }
    }
}
