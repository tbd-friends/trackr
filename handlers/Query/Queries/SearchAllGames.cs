using System.Collections.Generic;
using MediatR;
using viewmodels;

namespace handlers.Queries
{
    public class SearchAllGames : IRequest<IEnumerable<SearchResultViewModel>>
    {
        public string Text { get; set; }
        public bool IncludeOnlyWanted { get; set; }
        public bool IncludeWithCopies { get; set; }
    }
}