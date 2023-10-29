using CupcakeServer.CQRS.Commands.Users;
using CupcakeServer.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CupcakeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByUserId(int id)
        {
            return Ok(await mediator.Send(new GetUserProfileQuery { UserId = id }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserProfileCommand command)
        {
            command.UserId = id;
            return Ok(await mediator.Send(command));
        }
    }
}
