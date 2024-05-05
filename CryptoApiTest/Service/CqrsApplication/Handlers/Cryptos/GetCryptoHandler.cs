using AutoMapper;
using Contracts;
using CqrsApplication.Queries.Cryptos;
using MediatR;
using Shared.DataTransferObject;

namespace CqrsApplication.Handlers.Cryptos
{
    public sealed class GetCryptoHandler : IRequestHandler<GetCryptoQuery, CryptoDto>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GetCryptoHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repository = repositoryManager;
            _mapper = mapper;
        }

        public async Task<CryptoDto> Handle(GetCryptoQuery request, CancellationToken cancellationToken)
        {
            var crypto = await _repository.Crypto.GetCryptoAsync(request.id, request.trackChanges);
            return _mapper.Map<CryptoDto>(crypto);
        }
    }
}
