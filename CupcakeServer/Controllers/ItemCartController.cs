using CupcakeServer.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CupcakeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ItemCartController : ControllerBase
    {
        private IMediator mediator;
        public ItemCartController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateItemCartCommand command)
        {
            command.Id = id;
            return Ok(await mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await mediator.Send(new DeleteItemCartCommnand { Id = id }));
        }

    }
}
