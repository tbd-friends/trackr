using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using handlers.Commands;
using handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using viewmodels;

namespace view.Controllers
{
    [ApiController]
    [Route("games")]
    public class GameController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<GameViewModel>> Games()
        {
            return await _mediator.Send(new GetGames());
        }

        [HttpGet, Route("{id}")]
        public async Task<GameTitleViewModel> GetGame(Guid id)
        {
            return await _mediator.Send(new GetGameById { Id = id });
        }

        [HttpDelete, Route("{id}")]
        public async Task DeleteGame(Guid id)
        {
            await _mediator.Send(new DeleteGame() { GameId = id });
        }
    }
}