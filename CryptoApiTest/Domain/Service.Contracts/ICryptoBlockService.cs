using Shared.DataTransferObject;

namespace Service.Contracts
{
    public interface ICryptoBlockService
    {
        Task<CryptoBlockDto> CreateCryptoBlockAsync(long cryptoNetworkId, CryptoBlockForManipulationDto crypto);
        Task<CryptoBlockDto> GetLastCryptoBlockOfNetworkAsync(long cryptoNetworkId);
        Task<CryptoBlockDto> GetFirstCryptoBlockOfNetworkAsync(long cryptoNetworkId);
        Task<CryptoBlockDto> GetByHashAsync(string hash);
    }
}
