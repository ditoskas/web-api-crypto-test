using AutoMapper;
using Contracts;
using CqrsApplication.Commands.Cryptos;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObject;

namespace CqrsApplication.Handlers.Cryptos
{
    public sealed class UpdateCryptoHandler : IRequestHandler<UpdateCryptoCommand, CryptoDto>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public UpdateCryptoHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repository = repositoryManager;
            _mapper = mapper;
        }

        public async Task<CryptoDto> Handle(UpdateCryptoCommand request, CancellationToken cancellationToken)
        {
            var crypto = await _repository.Crypto.GetCryptoAsync(request.cryptoId, false);

            if (crypto is null)
            {
                throw new CryptoNotfound(request.cryptoId);
            }

            _mapper.Map(request.crypto, crypto);
            await _repository.SaveAsync();

            crypto = await _repository.Crypto.GetCryptoAsync(request.cryptoId, false);
            return _mapper.Map<CryptoDto>(crypto);
        }
    }
}
