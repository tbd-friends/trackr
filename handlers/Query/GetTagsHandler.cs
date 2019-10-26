using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using handlers.Queries;
using MediatR;
using persistence;

namespace handlers
{
    public class GetTagsHandler : IRequestHandler<GetTags, IEnumerable<string>>
    {
        private readonly GamesContext _dataStore;

        public GetTagsHandler(GamesContext dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task<IEnumerable<string>> Handle(GetTags request, CancellationToken cancellationToken)
        {
            var tags = from attr in _dataStore.Tags
                                    orderby attr.Value
                                    select attr.Value;

            return await Task.FromResult(tags);
        }
    }
}