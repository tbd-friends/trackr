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
    [Route("game-copies")]
    public class GameCopyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GameCopyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task AddGameCopy(AddGameCopyInputModel model)
        {
            await _mediator.Send(new AddGameCopy
            {
                GameId = model.GameId,
                PricePaid = model.PricePaid,
                PurchasedOn = model.PurchasedOn,
                Tags = model.Tags
            });
        }

        [HttpGet, Route("{id}")]
        public async Task<IEnumerable<GameCopyViewModel>> GetGameCopies(Guid id)
        {
            return await _mediator.Send(new GetGameCopies
            {
                Id = id
            });
        }
    }
}