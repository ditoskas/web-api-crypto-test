using MediatR;
using Shared.DataTransferObject;

namespace CqrsApplication.Commands.Cryptos
{
    public sealed record DeleteCryptoCommand(long cryptoId) : IRequest<bool>
    {
    }
}
