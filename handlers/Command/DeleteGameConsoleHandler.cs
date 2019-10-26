using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using handlers.Commands;
using MediatR;
using persistence;

namespace handlers
{
    public class DeleteGameConsoleHandler : IRequestHandler<DeleteGameConsole>
    {
        private readonly GamesContext _store;

        public DeleteGameConsoleHandler(GamesContext store)
        {
            _store = store;
        }

        public async Task<Unit> Handle(DeleteGameConsole request, CancellationToken cancellationToken)
        {
            var system = _store.GameConsoles.Single(s => s.Id == request.SystemId);

            _store.Remove(system);

            await _store.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}