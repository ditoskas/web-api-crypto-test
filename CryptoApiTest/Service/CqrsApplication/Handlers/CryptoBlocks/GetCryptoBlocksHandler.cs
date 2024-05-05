using AutoMapper;
using Contracts;
using CqrsApplication.Queries.CryptoBlocks;
using CqrsApplication.Queries.Cryptos;
using MediatR;
using Shared.DataTransferObject;
using Shared.RequestFeatures;

namespace CqrsApplication.Handlers.CryptoBlocks
{
    public sealed class GetCryptoBlocksHandler : IRequestHandler<GetCryptoBlocksQuery, CryptoBlockWithMetaDataDto>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GetCryptoBlocksHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repository = repositoryManager;
            _mapper = mapper;
        }

        public async Task<CryptoBlockWithMetaDataDto> Handle(GetCryptoBlocksQuery request, CancellationToken cancellationToken)
        {
            var cryptoBlocks = await _repository.CryptoBlock.GetCryptoBlocksAsync(request.cryptoBlockParameters, false);
            var cryptoBlocksDto = _mapper.Map<IEnumerable<CryptoBlockDto>>(cryptoBlocks);
            return new CryptoBlockWithMetaDataDto(cryptoBlocksDto, cryptoBlocks.MetaData);
        }
    }
}
