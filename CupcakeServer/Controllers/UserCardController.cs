using CupcakeServer.CQRS.Commands.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CupcakeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCardController : ControllerBase
    {
        private IMediator mediator;
        public UserCardController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCardCommand command)
        {
            return Ok(await mediator.Send(command));
        }


    }
}
