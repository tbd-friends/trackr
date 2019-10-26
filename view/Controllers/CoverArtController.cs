using System;
using System.IO;
using System.Threading.Tasks;
using handlers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SystemFile = System.IO.File;

namespace view.Controllers
{
    [ApiController]
    [Route("cover-art")]
    public class CoverArtController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _coverArtPath;

        public CoverArtController(IConfiguration configuration, IMediator mediator)
        {
            _mediator = mediator;
            _coverArtPath = configuration["coverArt:path"];
        }

        [HttpGet, Route("{id}")]
        public Task<string> LoadImage(Guid id)
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, _coverArtPath, $"{id}");

            if (!SystemFile.Exists(filePath))
            {
                filePath = Path.Combine(AppContext.BaseDirectory, _coverArtPath, "game_cover.png");
            }

            string asBase64 = Convert.ToBase64String(SystemFile.ReadAllBytes(filePath));

            return Task.FromResult($"data:image/jpg;base64,{asBase64}");
        }

        [HttpDelete, Route("{id}")]
        public async Task DeleteCoverArt(Guid id)
        {
            await _mediator.Send(new DeleteCoverArt { Id = id });
        }
    }
}