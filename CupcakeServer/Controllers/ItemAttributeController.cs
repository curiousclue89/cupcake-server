using CupcakeServer.CQRS.Commands.Items;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CupcakeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemAttributeController: ControllerBase
    {
        private IMediator mediator;
        public ItemAttributeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemAttributeCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
