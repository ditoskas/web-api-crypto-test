using AutoMapper;
using Contracts;
using CqrsApplication.Commands.Cryptos;
using Entities.Exceptions;
using MediatR;

namespace CqrsApplication.Handlers.Cryptos
{
    public sealed class DeleteCryptoHandler : IRequestHandler<DeleteCryptoCommand, bool>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public DeleteCryptoHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repository = repositoryManager;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteCryptoCommand request, CancellationToken cancellationToken)
        {
            var cryptoToDelete = await _repository.Crypto.GetCryptoAsync(request.cryptoId, false);

            if (cryptoToDelete is null)
            {
                throw new CryptoNotfound(request.cryptoId);
            }

            _repository.Crypto.DeleteCrypto(cryptoToDelete);
            await _repository.SaveAsync();
            return true;
        }
    }
}
