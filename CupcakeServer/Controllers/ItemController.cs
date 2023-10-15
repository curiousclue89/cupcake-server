using CupcakeServer.CQRS.Commands.Items;
using CupcakeServer.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace CupcakeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController: ControllerBase
    {
        private IMediator mediator;
        public ItemController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllItemQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByCategoryId(int id)
        {
            return Ok(await mediator.Send(new GetItemByCategoryQuery { CategoryId = id }));
        }
    }
}
