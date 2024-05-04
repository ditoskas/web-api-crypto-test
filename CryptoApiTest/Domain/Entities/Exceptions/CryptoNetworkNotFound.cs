namespace Entities.Exceptions
{
    public class CryptoNetworkNotFound : NotFoundException
    {
        public CryptoNetworkNotFound(long cryptoNetworkId) : base($"Crypto Network with id: {cryptoNetworkId} doesn't exist in the database.")
        {
        }
        public CryptoNetworkNotFound(string symbol, string chain) : base($"Crypto Network with id: {symbol} . {chain} doesn't exist in the database.")
        {
        }
    }
}
