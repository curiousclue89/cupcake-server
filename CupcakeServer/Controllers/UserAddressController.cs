using CupcakeServer.CQRS.Commands.Users;
using CupcakeServer.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CupcakeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressController: ControllerBase
    {
        private IMediator mediator;
        public UserAddressController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserAddressCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByUserId(int id)
        {
            return Ok(await mediator.Send(new GetAddressQuery { UserId = id }));
        }


    }
}
