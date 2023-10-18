using CupcakeServer.CQRS.Commands;
using CupcakeServer.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CupcakeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController: ControllerBase
    {
        private IMediator mediator;

        public CartController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCartCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send(new GetCartByIdQuery { CartId = id }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCartCommand command)
        {
            command.Id = id;
            return Ok(await mediator.Send(command));
        }

    }
}
