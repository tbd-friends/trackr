using System.Collections;
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
    public class GetGameConsolesHandler : IRequestHandler<GetGameConsoles, IEnumerable<GameConsoleViewModel>>
    {
        private readonly GamesContext _context;

        public GetGameConsolesHandler(GamesContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<GameConsoleViewModel>> Handle(GetGameConsoles request, CancellationToken cancellationToken)
        {
            var results = (from s in _context.GameConsoles
                           select new GameConsoleViewModel { Id = s.Id, Name = s.Name, Manufacturer = s.Manufacturer }).ToList();

            return Task.FromResult<IEnumerable<GameConsoleViewModel>>(results);
        }
    }
}