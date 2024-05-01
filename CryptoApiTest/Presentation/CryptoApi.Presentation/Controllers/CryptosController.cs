using Entities.ApiResponses;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApi.Presentation.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CryptosController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CryptosController(IServiceManager service) => _service = service;

        [HttpGet(Name = "GetCryptos")]
        public async Task<IActionResult> GetCryptos()
        {
            var cryptos = await _service.CryptoService.GetAllCryptosAsync(false);

            return new OkApiResult(cryptos);
        }

        [HttpGet("{id:long}", Name = "CryptoById")]
        public async Task<IActionResult> GetCompany(long id)
        {
            var crypto = await _service.CryptoService.GetCryptoAsync(id, false);
            return new OkApiResult(crypto);
        }
    }
}
