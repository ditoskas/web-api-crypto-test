using MediatR;
using Shared.DataTransferObject;

namespace CqrsApplication.Commands.Cryptos
{
    public sealed record UpdateCryptoCommand(long cryptoId, CryptoForUpdateDto crypto) : IRequest<CryptoDto>
    {
    }
}
