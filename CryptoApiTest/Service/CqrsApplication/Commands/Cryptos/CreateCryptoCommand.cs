using MediatR;
using Shared.DataTransferObject;

namespace CqrsApplication.Commands.Cryptos
{
    public sealed record CreateCryptoCommand(CryptoForCreationDto crypto) : IRequest<CryptoDto>
    {
    }
}
