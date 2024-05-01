using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObject;

namespace Service
{
    public sealed class CryptoService : BaseService, ICryptoService
    {
        public CryptoService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper): base(repository, logger, mapper)
        {
        }

        public async Task<IEnumerable<CryptoDto>> GetAllCryptosAsync(bool trackChanges)
        {
            var cryptos = await _repository.Crypto.GetAllCryptosAsync(trackChanges);
            
            return _mapper.Map<IEnumerable<CryptoDto>>(cryptos);
        }

        public async Task<CryptoDto> GetCryptoAsync(long cryptoId, bool trackChanges)
        {
            var crypto = await GetCryptoIfExists(cryptoId, trackChanges);

            return _mapper.Map<CryptoDto>(crypto);
        }

        private async Task<Crypto> GetCryptoIfExists(long cryptoId, bool trackChanges)
        {
            var crypto = await _repository.Crypto.GetCryptoAsync(cryptoId, trackChanges);

            if (crypto is null)
            {
                _logger.LogInfo($"Crypto with id: {cryptoId} doesn't exist in the database.");
                throw new CryptoNotfound(cryptoId);
            }

            return crypto;
        }
    }
}
