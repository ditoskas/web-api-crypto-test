using Entities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.RequestFeatures;
using Utilities;

namespace CryptoApi.Presentation.Controllers
{
    [ResponseCache(CacheProfileName = "60SecondsDuration")]
    public class CryptoBlocksController : BaseCryptoController
    {
        public CryptoBlocksController(IServiceManager service) : base(service) { }

        [HttpGet(Name = "GetCryptoBlocks")]
        public async Task<IActionResult> GetCryptoBlocks([FromQuery]CryptoBlockParameters cryptoBlockParameters)
        {
            var cryptoBlocks = await _service.CryptoBlockService.GetCryptoBlocksAsync(cryptoBlockParameters);
            Response.Headers.Append("X-Pagination", Serializer.SerializeObject(cryptoBlocks.MetaData));

            return new OkApiResult(cryptoBlocks.CryptoBlocks);
        }

        [HttpGet("{hash}", Name = "CryptoBlockByHash")]
        public async Task<IActionResult> CryptoBlockByHash(string hash)
        {
            var cryptoBlock = await _service.CryptoBlockService.GetByHashAsync(hash);
            return new OkApiResult(cryptoBlock);
        }
    }
}
