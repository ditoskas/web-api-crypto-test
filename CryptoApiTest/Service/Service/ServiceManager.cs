using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service
{
    public sealed class ServiceManager: IServiceManager
    {
        private readonly Lazy<ICryptoService> _cryptoService;
        private readonly Lazy<ICryptoBlockService> _cryptoBlockService;
        private readonly Lazy<ICryptoNetworkService> _cryptoNetworkService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _cryptoService = new Lazy<ICryptoService>(() => new CryptoService(repositoryManager, logger, mapper));
            _cryptoBlockService = new Lazy<ICryptoBlockService>(() => new CryptoBlockService(repositoryManager, logger, mapper));
            _cryptoNetworkService = new Lazy<ICryptoNetworkService>(() => new CryptoNetworkService(repositoryManager, logger, mapper));
        }

        public ICryptoService CryptoService => _cryptoService.Value;

        public ICryptoBlockService CryptoBlockService => _cryptoBlockService.Value;

        public ICryptoNetworkService CryptoNetworkService => _cryptoNetworkService.Value;
    }
}
