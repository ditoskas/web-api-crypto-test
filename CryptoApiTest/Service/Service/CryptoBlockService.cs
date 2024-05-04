using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObject;
using Shared.RequestFeatures;
using System.ComponentModel.Design;

namespace Service
{
    public sealed class CryptoBlockService : BaseService, ICryptoBlockService
    {
        public CryptoBlockService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper): base(repository, logger, mapper)
        {
        }

        public async Task<CryptoDto> CreateCryptoAsync(CryptoForCreationDto crypto)
        {
            var cryptoEntity = _mapper.Map<Crypto>(crypto);
            _repository.Crypto.CreateCrypto(cryptoEntity);
            await _repository.SaveAsync();

            return _mapper.Map<CryptoDto>(cryptoEntity);
        }

        public async Task<CryptoBlockDto> CreateCryptoBlockAsync(long cryptoNetworkId, CryptoBlockForManipulationDto cryptoBlock)
        {
            CryptoNetwork cryptoNetwork = await GetCryptoNetworkIfExists(cryptoNetworkId, false);

            var cryptoBlockEntity = _mapper.Map<CryptoBlock>(cryptoBlock);
            cryptoBlockEntity.CryptoNetworkId = cryptoNetwork.Id;
            cryptoBlockEntity.CreatedAt = DateTime.UtcNow;

            _repository.CryptoBlock.CreateCryptoBlock(cryptoBlockEntity);
            await _repository.SaveAsync();
            return _mapper.Map<CryptoBlockDto>(cryptoBlockEntity);

        }

        public async Task<CryptoBlockDto> GetByHashAsync(string hash)
        {
            var block = await _repository.CryptoBlock.GetByHashAsync(hash, false);
            return _mapper.Map<CryptoBlockDto>(block);
        }

        public async Task<CryptoBlockDto> GetFirstCryptoBlockOfNetworkAsync(long cryptoNetworkId)
        {
            CryptoNetwork cryptoNetwork = await GetCryptoNetworkIfExists(cryptoNetworkId, false);
            var block = await _repository.CryptoBlock.GetFirstCryptoBlockOfNetworkAsync(cryptoNetworkId, false);
            return _mapper.Map<CryptoBlockDto>(block);
        }

        public async Task<CryptoBlockDto> GetLastCryptoBlockOfNetworkAsync(long cryptoNetworkId)
        {
            CryptoNetwork cryptoNetwork = await GetCryptoNetworkIfExists(cryptoNetworkId, false);
            var block = await _repository.CryptoBlock.GetLastCryptoBlockOfNetworkAsync(cryptoNetworkId, false);
            return _mapper.Map<CryptoBlockDto>(block);
        }

        public async Task<CryptoBlockWithMetaDataDto> GetCryptoBlocksAsync(CryptoBlockParameters cryptoBlockParameters)
        {
            var cryptoBlocks = await _repository.CryptoBlock.GetCryptoBlocksAsync(cryptoBlockParameters, false);
            var cryptoBlocksDto = _mapper.Map<IEnumerable<CryptoBlockDto>>(cryptoBlocks);
            return new CryptoBlockWithMetaDataDto(cryptoBlocksDto, cryptoBlocks.MetaData);
        }

        private async Task<CryptoNetwork> GetCryptoNetworkIfExists(long cryptoNetworkId, bool trackChanges)
        {
            var cryptoNetwork = await _repository.CryptoNetwork.GetCryptoWithNetworkAsync(cryptoNetworkId, trackChanges);

            if (cryptoNetwork is null)
            {
                _logger.LogInfo($"Crypto network with id: {cryptoNetworkId} doesn't exist in the database.");
                throw new CryptoNetworkNotFound(cryptoNetworkId);
            }

            return cryptoNetwork;
        }
    }
}
