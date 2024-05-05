using AutoMapper;
using Contracts;
using CqrsApplication.Queries.CryptoBlocks;
using CqrsApplication.Queries.Cryptos;
using MediatR;
using Shared.DataTransferObject;

namespace CqrsApplication.Handlers.CryptoBlocks
{
    public sealed class GetCryptoBlockByHashHandler : IRequestHandler<GetCryptoBlockByHashQuery, CryptoBlockDto>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GetCryptoBlockByHashHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repository = repositoryManager;
            _mapper = mapper;
        }

        public async Task<CryptoBlockDto> Handle(GetCryptoBlockByHashQuery request, CancellationToken cancellationToken)
        {
            var block = await _repository.CryptoBlock.GetByHashAsync(request.hash, false);
            return _mapper.Map<CryptoBlockDto>(block);
        }
    }
}
