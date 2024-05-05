using MediatR;
using Shared.DataTransferObject;

namespace CqrsApplication.Queries.CryptoBlocks
{
    public sealed record GetCryptoBlockByHashQuery(string hash, bool trackChanges) : IRequest<CryptoBlockDto>;
}
