using CupcakeServer.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CupcakeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
