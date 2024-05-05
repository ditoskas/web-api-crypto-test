using CqrsApplication.Queries.CryptoBlocks;
using Entities.ApiResponses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Shared.RequestFeatures;
using Utilities;

namespace Api2.Controllers
{
    public class CryptoBlocksController : BaseCryptoController
    {
        public CryptoBlocksController(ISender sender, IPublisher publisher) : base(sender, publisher) { }

        [HttpGet(Name = "GetCryptoBlocks")]
        [OutputCache(Duration = 60)]
        public async Task<IActionResult> GetCryptoBlocks([FromQuery] CryptoBlockParameters cryptoBlockParameters)
        {
            var cryptoBlocks = await _sender.Send(new GetCryptoBlocksQuery(cryptoBlockParameters, false));
            Response.Headers.Append("X-Pagination", Serializer.SerializeObject(cryptoBlocks.MetaData));

            return new OkApiResult(cryptoBlocks.CryptoBlocks);
        }

        [HttpGet("{hash}", Name = "CryptoBlockByHash")]
        public async Task<IActionResult> CryptoBlockByHash(string hash)
        {
            var cryptoBlock = await _sender.Send(new GetCryptoBlockByHashQuery(hash, false));
            return new OkApiResult(cryptoBlock);
        }
    }
}
