using Shared.DataTransferObject;

namespace Service.Contracts
{
    public interface ICryptoService
    {
        Task<IEnumerable<CryptoDto>> GetAllCryptosAsync(bool trackChanges);
        Task<CryptoDto> GetCryptoAsync(long cryptoId, bool trackChanges);

    }
}
