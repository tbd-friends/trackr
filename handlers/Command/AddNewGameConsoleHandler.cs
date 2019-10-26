using System;
using System.Threading;
using System.Threading.Tasks;
using handlers.Commands;
using MediatR;
using models;
using persistence;

namespace handlers
{
    public class AddNewGameConsoleHandler : IRequestHandler<AddNewGameConsole>
    {
        private readonly GamesContext _store;

        public AddNewGameConsoleHandler(GamesContext store)
        {
            _store = store;
        }

        public async Task<Unit> Handle(AddNewGameConsole request, CancellationToken cancellationToken)
        {
            _store.Add(new GameConsole
            {
                Name = request.Name,
                Manufacturer = request.Manufacturer,
                ReleaseYear = request.YearOfRelease
            });

            await _store.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}