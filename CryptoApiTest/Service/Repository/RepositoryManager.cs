using Contracts;

namespace Repository
{
    public sealed class RepositoryManager: IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ICryptoRepository> _cryptoRepository;
        private readonly Lazy<ICryptoNetworkRepository> _cryptoNetworkRepository;
        private readonly Lazy<ICryptoBlockRepository> _cryptoBlockRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _cryptoRepository = new Lazy<ICryptoRepository>(() => new CryptoRepository(repositoryContext));
            _cryptoNetworkRepository = new Lazy<ICryptoNetworkRepository>(() => new CryptoNetworkRepository(repositoryContext));
            _cryptoBlockRepository = new Lazy<ICryptoBlockRepository>(() => new CryptoBlockRepository(repositoryContext));

        }

        public ICryptoRepository Crypto => _cryptoRepository.Value;
        public ICryptoNetworkRepository CryptoNetwork => _cryptoNetworkRepository.Value;

        public ICryptoBlockRepository CryptoBlock => _cryptoBlockRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
