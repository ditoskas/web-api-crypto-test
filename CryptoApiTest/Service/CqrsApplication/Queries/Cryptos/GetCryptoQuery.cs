using MediatR;
using Shared.DataTransferObject;

namespace CqrsApplication.Queries.Cryptos
{
    public sealed record GetCryptoQuery(long id, bool trackChanges) : IRequest<CryptoDto>;
}
