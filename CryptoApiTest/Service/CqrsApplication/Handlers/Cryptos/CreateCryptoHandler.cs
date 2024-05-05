using AutoMapper;
using Contracts;
using CqrsApplication.Commands.Cryptos;
using Entities.Models;
using MediatR;
using Shared.DataTransferObject;

namespace CqrsApplication.Handlers.Cryptos
{
    public sealed class CreateCryptoHandler : IRequestHandler<CreateCryptoCommand, CryptoDto>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public CreateCryptoHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repository = repositoryManager;
            _mapper = mapper;
        }

        public async Task<CryptoDto> Handle(CreateCryptoCommand request, CancellationToken cancellationToken)
        {
            var cryptoEntity = _mapper.Map<Crypto>(request.crypto);
            _repository.Crypto.CreateCrypto(cryptoEntity);
            await _repository.SaveAsync();

            return _mapper.Map<CryptoDto>(cryptoEntity);
        }
    }
}
