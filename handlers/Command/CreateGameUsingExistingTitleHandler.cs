using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using handlers.Commands;
using MediatR;
using models;
using persistence;

namespace handlers
{
    public class CreateGameUsingExistingTitleHandler : IRequestHandler<CreateGameUsingExistingTitle>
    {
        private readonly GamesContext _context;

        public CreateGameUsingExistingTitleHandler(GamesContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateGameUsingExistingTitle request, CancellationToken cancellationToken)
        {
            bool exists =
                _context.Games.Any(st => st.GameConsoleId == request.GameConsole && st.TitleId == request.Title);

            if (!exists)
            {
                _context.Add(new Game
                {
                    GameConsoleId = request.GameConsole,
                    TitleId = request.Title,
                    ReleaseYear = request.YearOfRelease,
                    IsWanted = false
                });

                await _context.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}