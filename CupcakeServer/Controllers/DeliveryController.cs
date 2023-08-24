using CupcakeServer.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CupcakeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private IMediator mediator;
        public DeliveryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDeliveryCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
