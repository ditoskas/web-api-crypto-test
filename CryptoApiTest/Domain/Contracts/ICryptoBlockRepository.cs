using Entities.Models;

namespace Contracts
{
    /// <summary>
    /// Actions related with cryptoblocks table
    /// </summary>
    public interface ICryptoBlockRepository
    {
        void CreateCryptoBlock(CryptoBlock crypto);
        Task<CryptoBlock?> GetLastCryptoBlockOfNetworkAsync(long cryptoNetworkId, bool trackChanges);
        Task<CryptoBlock?> GetFirstCryptoBlockOfNetworkAsync(long cryptoNetworkId, bool trackChanges);
        Task<CryptoBlock?> GetByHashAsync(string hash, bool trackChanges);
    }
}
