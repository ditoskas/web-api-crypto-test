using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObject;
using System.ComponentModel.Design;

namespace Service
{
    public sealed class CryptoNetworkService : BaseService, ICryptoNetworkService
    {
        public CryptoNetworkService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper): base(repository, logger, mapper)
        {
        }

        public async Task<IEnumerable<CryptoNetworkDto>> GetAllCryptoWithNetworkAsync(bool trackChanges)
        {
            var cryptoNetworks = await _repository.CryptoNetwork.GetAllCryptoNetworksAsync(trackChanges);
            return _mapper.Map<IEnumerable<CryptoNetworkDto>>(cryptoNetworks);
        }

        public async Task<CryptoNetworkDto> GetCryptoWithNetworkAsync(long cryptoNetworkId, bool trackChanges)
        {
            var cryptoNetwork = await GetCryptoNetworkIfExists(cryptoNetworkId, trackChanges);
            return _mapper.Map<CryptoNetworkDto>(cryptoNetwork);
        }

        public async Task<CryptoNetworkDto> GetCryptoWithNetworkAsync(string symbol, string chain, bool trackChanges)
        {
            var cryptoNetwork = await _repository.CryptoNetwork.GetCryptoWithNetworkAsync(symbol, chain, trackChanges);

            if (cryptoNetwork is null)
            {
                _logger.LogInfo($"Crypto network with symbol: {symbol}.{chain} doesn't exist in the database.");
                throw new CryptoNetworkNotFound(symbol, chain);
            }
            return _mapper.Map<CryptoNetworkDto>(cryptoNetwork);
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
