﻿using CupcakeServer.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CupcakeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController: ControllerBase
    {
        private IMediator mediator;
        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}