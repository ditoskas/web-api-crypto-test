using Entities.Models;

namespace Contracts
{
    /// <summary>
    /// Actions related with cryptos table
    /// </summary>
    public interface ICryptoRepository
    {
        Task<IEnumerable<Crypto>> GetAllCryptosAsync(bool trackChanges);
        Task<Crypto?> GetCryptoAsync(long id, bool trackChanges);
        Task<Crypto?> GetCryptoWithNetworkAsync(string symbol, string chain, bool trackChanges);
        void CreateCrypto(Crypto crypto);
        void UpdateCrypto(Crypto crypto);
        void DeleteCrypto(Crypto crypto);
    }
}
