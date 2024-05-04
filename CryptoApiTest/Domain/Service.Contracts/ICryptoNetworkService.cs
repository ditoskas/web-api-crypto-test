using Shared.DataTransferObject;

namespace Service.Contracts
{
    public interface ICryptoNetworkService
    {
        Task<CryptoNetworkDto> GetCryptoWithNetworkAsync(long cryptoNetworkId, bool trackChanges);
        Task<CryptoNetworkDto> GetCryptoWithNetworkAsync(string symbol, string chain, bool trackChanges);
        Task<IEnumerable<CryptoNetworkDto>> GetAllCryptoWithNetworkAsync(bool trackChanges);
    }
}
