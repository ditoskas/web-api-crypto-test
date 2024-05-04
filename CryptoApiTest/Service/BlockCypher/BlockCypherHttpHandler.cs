using BlockCypher.Models;
using System.Net.Http.Headers;
using Utilities;

namespace BlockCypher
{
    public class BlockCypherHttpHandler
    {
        private static readonly Lazy<BlockCypherHttpHandler> lazy = new Lazy<BlockCypherHttpHandler>(() => new BlockCypherHttpHandler());
        private static readonly HttpClient client = new HttpClient();
        private BlockCypherHttpHandler() {
            // add content type header to json
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static BlockCypherHttpHandler Instance { get { return lazy.Value; } }

        public async Task<BlockCypherCryptoBlock?> GetBlockInfoAsync(string symbol, string network, string blockHash)
        {
            string url = BlockCypherUrlHandler.GetBlockInfoUrl(symbol, network, blockHash);
            return await GetBlockInfoAsync(url);
        }

        public async Task<BlockCypherCryptoBlock?> GetBlockInfoAsync(string url)
        {
            return await GetAsync<BlockCypherCryptoBlock>(url);
        }

        public async Task<BlockCypherNetwork?> GetNetworkAsync(string symbol, string network)
        {
            return await GetAsync<BlockCypherNetwork>(BlockCypherUrlHandler.GetNetworkUrl(symbol, network));
        }

        public async Task<string?> GetLastNetworkUrlAsync(string symbol, string network)
        {
            string? latestUrl = string.Empty;
            BlockCypherNetwork? cypherNetwork = await GetNetworkAsync(symbol, network);
            if (cypherNetwork != null)
            {
                latestUrl = cypherNetwork.LatestUrl;
            }
            return latestUrl;
        }

        public async Task<T?> GetAsync<T>(string url)
        {
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Serializer.DeserializeObjectSnakeCase<T>(content);
            }
            else
            {
                return default;
            }
        }
    }
}
