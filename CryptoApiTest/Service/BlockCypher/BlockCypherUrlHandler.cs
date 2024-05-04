namespace BlockCypher
{
    public class BlockCypherUrlHandler
    {
        public static string GetBaseUrl()
        {
            return $"https://api.blockcypher.com/v1";
        }

        public static string GetNetworkUrl(string symbol, string network)
        {
            return $"{GetBaseUrl()}/{symbol.ToLower()}/{network.ToLower()}";
        }
        public static string GetBlockInfoUrl(string symbol, string network, string blockHash)
        {
            return $"{GetNetworkUrl(symbol, network)}/blocks/{blockHash.ToLower()}";
        }
    }
}
