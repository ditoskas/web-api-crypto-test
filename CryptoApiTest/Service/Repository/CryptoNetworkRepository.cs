using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CryptoNetworkRepository : RepositoryBase<CryptoNetwork>, ICryptoNetworkRepository
    {
        public CryptoNetworkRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<IEnumerable<CryptoNetwork>> GetAllCryptoNetworksAsync(bool trackChanges) => await FindAll(trackChanges).Include(cn => cn.Crypto).ToListAsync();

        public async Task<IEnumerable<CryptoNetwork>> GetCryptoNetworksAsync(long cryptoId, bool trackChanges)
        {
            return await FindByCondition(c => c.CryptoId.Equals(cryptoId), trackChanges).ToListAsync();
        }

        public async Task<CryptoNetwork?> GetCryptoWithNetworkAsync(string symbol, string chain, bool trackChanges)
        {
            return await FindByCondition(cn => cn.Name.Equals(chain) && cn.Crypto.Symbol.Equals(symbol), trackChanges).SingleOrDefaultAsync();
        }

        public async Task<CryptoNetwork?> GetCryptoWithNetworkAsync(long cryptoNetworkId, bool trackChanges)
        {
            return await FindByCondition(cn => cn.Id.Equals(cryptoNetworkId), trackChanges).SingleOrDefaultAsync();
        }
    }
}
