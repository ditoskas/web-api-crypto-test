using Entities.Models;

namespace Contracts
{
    public interface ICryptoRepository
    {
        Task<IEnumerable<Crypto>> GetAllCryptosAsync(bool trackChanges);
        Task<Crypto?> GetCryptoAsync(long id, bool trackChanges);
        void CreateCrypto(Crypto crypto);
        void UpdateCrypto(Crypto crypto);
        void DeleteCrypto(Crypto crypto);
    }
}
