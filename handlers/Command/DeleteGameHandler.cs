using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using handlers.Commands;
using MediatR;
using persistence;

namespace handlers
{
    public class DeleteGameHandler : IRequestHandler<DeleteGame>
    {
        private readonly GamesContext _context;

        public DeleteGameHandler(GamesContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteGame request, CancellationToken cancellationToken)
        {
            ///TODO: Unit testing point! We shouldn't be able to delete a game if copies exist
            var game = _context.Games.Single(gt => gt.Id == request.GameId);

            _context.Remove(game);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}