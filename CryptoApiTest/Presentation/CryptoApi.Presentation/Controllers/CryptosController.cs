using CryptoApi.Presentation.ActionFilters;
using Entities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObject;

namespace CryptoApi.Presentation.Controllers
{
    public class CryptosController : BaseCryptoController
    {
        public CryptosController(IServiceManager service) : base(service) { }

        [HttpGet(Name = "GetCryptos")]
        public async Task<IActionResult> GetCryptos()
        {
            var cryptos = await _service.CryptoService.GetAllCryptosAsync(false);
            return new OkApiResult(cryptos);
        }

        [HttpGet("{id:long}", Name = "CryptoById")]
        public async Task<IActionResult> GetCrypto(long id)
        {
            var crypto = await _service.CryptoService.GetCryptoAsync(id, false);
            return new OkApiResult(crypto);
        }

        [HttpPost(Name = "CreateCrypto")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCrypto([FromBody] CryptoForCreationDto crypto)
        {
            var createdCrypto = await _service.CryptoService.CreateCryptoAsync(crypto);

            return await GetCrypto(createdCrypto.Id);
        }

        [HttpPut("{id:long}", Name = "UpdateCrypto")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCrypto(long id, [FromBody] CryptoForUpdateDto crypto)
        {
            var updatedCrypto = await _service.CryptoService.UpdateCryptoAsync(id, crypto, true);

            return await GetCrypto(updatedCrypto.Id);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteCompany(long id)
        {
            await _service.CryptoService.DeleteCryptoAsync(id, false);

            return new OkApiResult(null, "Crypto deleted successfully.");
        }
    }
}
