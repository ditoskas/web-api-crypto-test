using CryptoApi.Presentation.ActionFilters;
using Entities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObject;

namespace CryptoApi.Presentation.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseCryptoController : ControllerBase
    {
        protected readonly IServiceManager _service;
        public BaseCryptoController(IServiceManager service) => _service = service;

    }
}
