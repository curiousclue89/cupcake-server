using CupcakeServer.CQRS.Commands.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CupcakeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController: ControllerBase
    {
        private IMediator mediator;
        public UserProfileController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserProfileCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
