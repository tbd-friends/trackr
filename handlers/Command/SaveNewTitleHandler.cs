using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using handlers.Commands;
using MediatR;
using models;
using persistence;

namespace handlers
{
    public class SaveNewTitleHandler : IRequestHandler<CreateNewTitle, Guid>
    {
        private readonly GamesContext _context;

        public SaveNewTitleHandler(GamesContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateNewTitle request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                return Guid.Empty;
            }

            var existing = _context.Titles.SingleOrDefault(gt =>
                gt.Name.ToLower() == request.Name.ToLower());

            if (existing == null)
            {
                var newTitle = new Title
                {
                    Name = request.Name
                };

                _context.Add(newTitle);

                await _context.SaveChangesAsync(cancellationToken);

                return newTitle.Id;
            }

            return existing.Id;
        }
    }
}