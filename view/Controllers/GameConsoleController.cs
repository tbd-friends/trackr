using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using handlers.Commands;
using handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using view.Inputs;
using viewmodels;

namespace view.Controllers
{
    [ApiController]
    [Route("game-consoles")]
    public class GameConsoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GameConsoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task AddGameConsole(GameConsoleInputModel model)
        {
            await _mediator.Send(new AddNewGameConsole
            {
                Name = model.Name,
                Manufacturer = model.Manufacturer,
                YearOfRelease = model.YearOfRelease
            });
        }

        [HttpGet]
        public async Task<IEnumerable<GameConsoleViewModel>> GetAllConsoles()
        {
            return await _mediator.Send(new GetGameConsoles());
        }

        [HttpDelete, Route("{id}")]
        public async Task DeleteGameConsole(Guid id)
        {
            await _mediator.Send(new DeleteGameConsole
            {
                SystemId = id
            });
        }
    }
}