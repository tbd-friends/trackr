using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using handlers.Queries;
using MediatR;
using persistence;
using viewmodels;

namespace handlers
{
    public class GetGamesHandler : IRequestHandler<GetGames, IEnumerable<GameViewModel>>
    {
        private readonly GamesContext _context;

        public GetGamesHandler(GamesContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<GameViewModel>> Handle(GetGames request, CancellationToken cancellationToken)
        {
            var games = (from g in _context.Games
                        orderby g.Title.Name, g.GameConsole.Name, g.GameConsole.Manufacturer
                        select new GameViewModel
                        {
                            Id = g.Id,
                            Name = g.Title.Name,
                            Console = g.GameConsole.Name,
                            Manufacturer = g.GameConsole.Manufacturer
                        }).ToList();

            return Task.FromResult<IEnumerable<GameViewModel>>(games);
        }
    }
}