using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using handlers.Commands;
using MediatR;

namespace handlers
{
    public class SaveBatchGamesToSystemHandler : IRequestHandler<SaveBatchGamesToSystem>
    {
        private readonly IMediator _mediator;

        public SaveBatchGamesToSystemHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> Handle(SaveBatchGamesToSystem request, CancellationToken cancellationToken)
        {
            var titlesToAdd = ParseTitles(request.Titles).Where(t => !string.IsNullOrEmpty(t));

            foreach (var title in titlesToAdd)
            {
                var titleId = await _mediator.Send(new CreateNewTitle { Name = title }, cancellationToken);

                if (titleId != Guid.Empty)
                {
                    await _mediator.Send(new CreateGameUsingExistingTitle { GameConsole = request.SystemId, Title = titleId },
                        cancellationToken);
                }
            }

            return Unit.Value;
        }

        private IEnumerable<string> ParseTitles(string input)
        {
            return from x in input.Split("\n")
                   select x.Trim();
        }
    }
}