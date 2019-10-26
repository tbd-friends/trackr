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
    public class GetTitlesHandler : IRequestHandler<GetTitles, IEnumerable<TitleViewModel>>
    {
        private readonly GamesContext _context;

        public GetTitlesHandler(GamesContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<TitleViewModel>> Handle(GetTitles request, CancellationToken cancellationToken)
        {
            var results = (from s in _context.Titles
                           select new TitleViewModel { Id = s.Id, Name = s.Name }).ToList();

            return Task.FromResult<IEnumerable<TitleViewModel>>(results);
        }
    }
}