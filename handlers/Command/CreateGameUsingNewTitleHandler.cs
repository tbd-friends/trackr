using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using handlers.Commands;
using MediatR;
using persistence;

namespace handlers
{
    public class CreateGameUsingNewTitleHandler : IRequestHandler<CreateGameUsingNewTitle>
    {
        private readonly GamesContext _dataStore;
        private readonly IMediator _mediator;

        public CreateGameUsingNewTitleHandler(GamesContext dataStore, IMediator mediator)
        {
            _dataStore = dataStore;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateGameUsingNewTitle request, CancellationToken cancellationToken)
        {
            Guid titleId = await _mediator.Send(new CreateNewTitle { Name = request.Name }, cancellationToken);

            await _mediator.Send(new CreateGameUsingExistingTitle
            { GameConsole = request.ConsoleId, Title = titleId, YearOfRelease = request.YearOfRelease },
                cancellationToken);

            return Unit.Value;
        }
    }
}