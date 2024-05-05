using MediatR;
using Shared.DataTransferObject;
using Shared.RequestFeatures;

namespace CqrsApplication.Queries.CryptoBlocks
{
    public sealed record GetCryptoBlocksQuery(CryptoBlockParameters cryptoBlockParameters, bool trackChanges) : IRequest<CryptoBlockWithMetaDataDto>;
}
