using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using handlers.Commands;
using MediatR;
using persistence;

namespace handlers
{
    public class DeleteCoverArtHandler : IRequestHandler<DeleteCoverArt>
    {
        private readonly GamesContext _context;

        public DeleteCoverArtHandler(GamesContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCoverArt request, CancellationToken cancellationToken)
        {
            var game = _context.Games.Single(g => g.Id == request.Id);

            game.CoverArtUrl = null;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}