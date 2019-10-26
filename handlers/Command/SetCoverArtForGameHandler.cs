using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using handlers.Commands;
using MediatR;
using Microsoft.Extensions.Configuration;
using persistence;

namespace handlers
{
    public class SetCoverArtForGameHandler : IRequestHandler<SetCoverArtForGame>
    {
        private readonly GamesContext _dataStore;
        private readonly IMediator _mediator;
        private readonly string _scheme;

        public SetCoverArtForGameHandler(GamesContext dataStore, IMediator mediator, IConfiguration configuration)
        {
            _dataStore = dataStore;
            _mediator = mediator;
            _scheme = configuration["coverArt:scheme"];
        }

        public async Task<Unit> Handle(SetCoverArtForGame request, CancellationToken cancellationToken)
        {
            var game = _dataStore.Games.Single(s => s.Id == request.GameId);

            var imageUrl = PrepareUrlForSite(request.CoverArtUrl);

            string coverArtPath = await _mediator.Send(new CacheCoverArt
            { Id = game.Id, Url = imageUrl }, cancellationToken);

            game.CoverArtUrl = coverArtPath;

            _dataStore.Update(game);

            await _dataStore.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private string PrepareUrlForSite(string url)
        {
            url = url.Replace("t_thumb", "t_cover_small");

            if (!url.ToLower().StartsWith("http") &&
                !url.ToLower().StartsWith("https"))
            {
                return $"{_scheme}:{url}";
            }

            return url;
        }
    }
}