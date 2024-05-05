using Api2.ActionFilters;
using CqrsApplication.Commands.Cryptos;
using CqrsApplication.Notifications.Cryptos;
using CqrsApplication.Queries.Cryptos;
using Entities.ApiResponses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObject;

namespace Api2.Controllers
{
    public class CryptosController : BaseCryptoController
    {
        public CryptosController(ISender sender, IPublisher publisher) : base(sender, publisher) { }

        [HttpGet(Name = "GetCryptos")]
        public async Task<IActionResult> GetCryptos()
        {
            var cryptos = await _sender.Send(new GetCryptosQuery(false));
            return new OkApiResult(cryptos);
        }

        [HttpGet("{id:long}", Name = "CryptoById")]
        public async Task<IActionResult> GetCrypto(long id)
        {
            var crypto = await _sender.Send(new GetCryptoQuery(id, false));
            return new OkApiResult(crypto);
        }

        [HttpPost(Name = "CreateCrypto")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCrypto([FromBody] CryptoForCreationDto crypto)
        {
            var createdCrypto = await _sender.Send(new CreateCryptoCommand(crypto));

            return await GetCrypto(createdCrypto.Id);
        }

        [HttpPut("{id:long}", Name = "UpdateCrypto")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCrypto(long id, [FromBody] CryptoForUpdateDto crypto)
        {
            var updatedCrypto = await _sender.Send(new UpdateCryptoCommand(id,crypto));

            return await GetCrypto(updatedCrypto.Id);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteCompany(long id)
        {
            await _publisher.Publish(new DeleteCryptoNotification(id, false));

            return new OkApiResult(null, "Crypto deleted successfully.");
        }
    }
}
