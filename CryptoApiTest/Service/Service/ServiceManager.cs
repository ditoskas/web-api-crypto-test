using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service
{
    public sealed class ServiceManager: IServiceManager
    {
        private readonly Lazy<ICryptoService> _cryptoService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _cryptoService = new Lazy<ICryptoService>(() => new CryptoService(repositoryManager, logger, mapper));
        }

        public ICryptoService CryptoService => _cryptoService.Value;
    }
}
