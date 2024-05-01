namespace Entities.Exceptions
{
    public class CryptoNotfound : NotFoundException
    {
        public CryptoNotfound(long cryptoId) : base($"Crypto with id: {cryptoId} doesn't exist in the database.")
        {
        }
    }
}
