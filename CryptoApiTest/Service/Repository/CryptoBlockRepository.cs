using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Repository
{
    public class CryptoBlockRepository : RepositoryBase<CryptoBlock>, ICryptoBlockRepository
    {
        public CryptoBlockRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateCryptoBlock(CryptoBlock cryptoBlock) => Create(cryptoBlock);

        public async Task<CryptoBlock?> GetByHashAsync(string hash, bool trackChanges)
        {
            return await FindByCondition(c => c.Hash.Equals(hash), trackChanges).Include(t => t.Txids).Include(ti => ti.InternalTxids).FirstOrDefaultAsync();
        }

        public async Task<CryptoBlock?> GetFirstCryptoBlockOfNetworkAsync(long cryptoNetworkId, bool trackChanges)
        {
            return await FindByCondition(c => c.CryptoNetworkId.Equals(cryptoNetworkId), trackChanges).OrderBy(c => c.Time).FirstOrDefaultAsync();
        }

        public async Task<CryptoBlock?> GetLastCryptoBlockOfNetworkAsync(long cryptoNetworkId, bool trackChanges)
        {
            return await FindByCondition(c => c.CryptoNetworkId.Equals(cryptoNetworkId), trackChanges).OrderByDescending(c => c.Time).FirstOrDefaultAsync();
        }

        public async Task<PagedList<CryptoBlock>> GetCryptoBlocksAsync(CryptoBlockParameters cryptoBlockParameters, bool trackChanges)
        {
            var cryptoBlocks = await FindAll(trackChanges).Include(t => t.Txids).Include(ti => ti.InternalTxids).ToListAsync();
            return PagedList<CryptoBlock>.ToPagedList(cryptoBlocks, cryptoBlockParameters.PageNumber, cryptoBlockParameters.PageSize);
        }
    }
}
