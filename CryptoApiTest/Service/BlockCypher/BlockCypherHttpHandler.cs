using BlockCypher.Models;
using System.Net.Http.Headers;
using System.Text.Json;
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
        public static string GetBlockInfoUrl(string symbol, string network, string blockHash)
        {
            return $"{GetBaseUrl()}/{symbol}/{network}/blocks/{blockHash}";
        }

        public static string GetBaseUrl(
            )
        {
            return $"https://api.blockcypher.com/v1";
        }

        public async Task<BlockCypherCryptoBlock?> GetBlockInfoAsync(string symbol, string network, string blockHash)
        {
            string url = GetBlockInfoUrl(symbol, network, blockHash);
            return await GetBlockInfoAsync(url);
        }

        public async Task<BlockCypherCryptoBlock?> GetBlockInfoAsync(string url)
        {
            return await GetAsync<BlockCypherCryptoBlock>(url);
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
