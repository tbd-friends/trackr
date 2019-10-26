using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using handlers.Commands;
using MediatR;
using persistence;

namespace handlers
{
    public class ToggleWantedGameHandler : IRequestHandler<ToggleWantedGame>
    {
        private readonly GamesContext _dataStore;

        public ToggleWantedGameHandler(GamesContext dataStore)
        {
            _dataStore = dataStore;
        }

        public Task<Unit> Handle(ToggleWantedGame request, CancellationToken cancellationToken)
        {
            var game = _dataStore.Games.Single(st => st.Id == request.GameId);

            game.IsWanted = !game.IsWanted;

            _dataStore.Update(game);

            _dataStore.SaveChanges();

            return Task.FromResult(Unit.Value);
        }
    }
}