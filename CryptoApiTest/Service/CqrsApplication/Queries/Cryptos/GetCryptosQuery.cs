using MediatR;
using Shared.DataTransferObject;

namespace CqrsApplication.Queries.Cryptos
{
    public sealed record GetCryptosQuery(bool trackChanges) : IRequest<IEnumerable<CryptoDto>>;
}
