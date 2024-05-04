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
            var cryptoBlocks = FindAll(false).Where(c => c.Height >= cryptoBlockParameters.HeightMin && c.Height <= cryptoBlockParameters.HeightMax);
            if (!string.IsNullOrEmpty(cryptoBlockParameters.Hash))
            {
                cryptoBlocks = cryptoBlocks.Where(c => c.Hash.Equals(cryptoBlockParameters.Hash));
            }
            if (!string.IsNullOrEmpty(cryptoBlockParameters.Chain))
            {
                cryptoBlocks = cryptoBlocks.Where(c => c.Chain.Equals(cryptoBlockParameters.Chain));
            }
            if ( cryptoBlockParameters.TimeMin.HasValue)
            {
                cryptoBlocks = cryptoBlocks.Where(c => c.Time > cryptoBlockParameters.TimeMin);
            }

            if (cryptoBlockParameters.TimeMax.HasValue)
            {
                cryptoBlocks = cryptoBlocks.Where(c => c.Time < cryptoBlockParameters.TimeMax);
            }

            var count = await cryptoBlocks.CountAsync();
            var cryptoBlocksResult = await cryptoBlocks.OrderByDescending(c => c.CreatedAt)
                                                       .Skip((cryptoBlockParameters.PageNumber - 1) * cryptoBlockParameters.PageSize)
                                                       .Take(cryptoBlockParameters.PageSize)
                                                       .Include(t => t.Txids)
                                                       .Include(ti => ti.InternalTxids)
                                                       .ToListAsync();
            return new PagedList<CryptoBlock>(cryptoBlocksResult, count, cryptoBlockParameters.PageNumber, cryptoBlockParameters.PageSize);
        }
    }
}
