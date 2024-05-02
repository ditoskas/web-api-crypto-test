using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObject;
using System.ComponentModel.Design;

namespace Service
{
    public sealed class CryptoService : BaseService, ICryptoService
    {
        public CryptoService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper): base(repository, logger, mapper)
        {
        }

        public async Task<CryptoDto> CreateCryptoAsync(CryptoForCreationDto crypto)
        {
            var cryptoEntity = _mapper.Map<Crypto>(crypto);
            _repository.Crypto.CreateCrypto(cryptoEntity);
            await _repository.SaveAsync();

            return _mapper.Map<CryptoDto>(cryptoEntity);
        }

        public async Task DeleteCryptoAsync(long id, bool trackChanges)
        {
            var cryptoToDelete = await GetCryptoIfExists(id, trackChanges);

            _repository.Crypto.DeleteCrypto(cryptoToDelete);
            await _repository.SaveAsync();
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

        public async Task<CryptoDto> UpdateCryptoAsync(long id, CryptoForUpdateDto cryptoForUpdate, bool trackChanges)
        {
            var crypto = await GetCryptoIfExists(id, trackChanges);
            _mapper.Map(cryptoForUpdate, crypto);
            await _repository.SaveAsync();
            return  await GetCryptoAsync(id, trackChanges);
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
