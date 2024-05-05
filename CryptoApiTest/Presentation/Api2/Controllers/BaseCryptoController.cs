using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseCryptoController : ControllerBase
    {
        protected readonly ISender _sender;
        protected readonly IPublisher _publisher;
        public BaseCryptoController(ISender sender, IPublisher publisher)
        {
            _sender = sender;
            _publisher = publisher;
        }
    }
}
