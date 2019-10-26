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
    [Route("titles")]
    public class TitleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TitleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task AddNewTitle(TitleInputModel model)
        {
            await _mediator.Send(new CreateNewTitle
            {
                Name = model.Name
            });
        }

        [HttpPost, Route("{id:guid}/games")]
        public async Task SaveGameToSystem(Guid id, NewGameExistingTitleInputModel model)
        {
            await _mediator.Send(new CreateGameUsingExistingTitle
            {
                GameConsole = model.GameConsoleId,
                Title = id,
                YearOfRelease = model.YearOfRelease
            });
        }

        [HttpPost, Route("{title}/games")]
        public async Task SaveNewGameToSystem(string title, NewGameNewTitleInputModel model)
        {
            await _mediator.Send(new CreateGameUsingNewTitle
            {
                ConsoleId = model.GameConsoleId,
                Name = title,
                YearOfRelease = model.YearOfRelease
            });
        }

        [HttpGet]
        public async Task<IEnumerable<TitleViewModel>> GetAllTitles()
        {
            return await _mediator.Send(new GetTitles());
        }

        [HttpDelete, Route("{id}")]
        public async Task DeleteTitle(Guid id)
        {
            await _mediator.Send(new DeleteGame
            {
                GameId = id
            });
        }
    }
}