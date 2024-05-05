using MediatR;

namespace CqrsApplication.Notifications.Cryptos
{
    public sealed record DeleteCryptoNotification(long cryptoId, bool TrackChanges) : INotification;
}
