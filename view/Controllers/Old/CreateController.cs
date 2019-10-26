using System;
using System.Threading.Tasks;
using handlers.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using view.Inputs;

namespace view.Controllers
{
    [ApiController]
    [Route("save")]
    public class CreateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost, Route("titles-batch")]
        public async Task SaveTitlesBatch(BatchGameForSystemInputModel model)
        {
            await _mediator.Send(new SaveBatchGamesToSystem
            {
                SystemId = model.System,
                Titles = model.Titles
            });
        }

        [HttpPost, Route("cover-art")]
        public async Task SaveCoverArt(CoverArtForGameInputModel model)
        {
            await _mediator.Send(new SetCoverArtForGame
            {
                GameId = model.GameId,
                CoverArtUrl = model.Url
            });
        }

        [HttpPost, Route("toggle-is-wanted/{id}")]
        public async Task ToggleIsFavorite(Guid id)
        {
            await _mediator.Send(new ToggleWantedGame { GameId = id });
        }
    }
}