using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager: IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ICryptoRepository> _cryptoRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _cryptoRepository = new Lazy<ICryptoRepository>(() => new CryptoRepository(repositoryContext));

        }

        public ICryptoRepository Crypto => _cryptoRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
