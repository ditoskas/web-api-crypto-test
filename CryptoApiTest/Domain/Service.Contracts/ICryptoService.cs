using Shared.DataTransferObject;

namespace Service.Contracts
{
    public interface ICryptoService
    {
        Task<IEnumerable<CryptoDto>> GetAllCryptosAsync(bool trackChanges);
        Task<CryptoDto> GetCryptoAsync(long cryptoId, bool trackChanges);
        Task<CryptoDto> CreateCryptoAsync(CryptoForCreationDto crypto);
        Task<CryptoDto> UpdateCryptoAsync(long id, CryptoForUpdateDto crypto, bool trackChanges);
        Task DeleteCryptoAsync(long id, bool trackChanges);
    }
}
