using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseCryptoController : ControllerBase
    {
        protected readonly ISender _sender;
        public BaseCryptoController(ISender sender)
        {
            _sender = sender;
        }
    }
}
