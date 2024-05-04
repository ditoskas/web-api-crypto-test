using Entities.Models;

namespace Contracts
{
    /// <summary>
    /// Actions related with cryptonetworks table
    /// </summary>
    public interface ICryptoNetworkRepository
    {
        Task<IEnumerable<CryptoNetwork>> GetCryptoNetworksAsync(long cryptoId, bool trackChanges);
        Task<IEnumerable<CryptoNetwork>> GetAllCryptoNetworksAsync(bool trackChanges);
        Task<CryptoNetwork?> GetCryptoWithNetworkAsync(string symbol, string chain, bool trackChanges);
        Task<CryptoNetwork?> GetCryptoWithNetworkAsync(long cryptoNetworkId, bool trackChanges);
    }
}
