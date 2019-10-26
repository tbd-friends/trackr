using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using core;
using handlers.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using persistence;
using viewmodels;

namespace handlers
{
    public class FindGamesMatchingTitleHandler : IRequestHandler<FindMatchingTitles, IEnumerable<string>>
    {
        private readonly GamesContext _dataStore;
        private readonly IProvideGamesData _provider;

        public FindGamesMatchingTitleHandler(GamesContext dataStore, IProvideGamesData provider)
        {
            _dataStore = dataStore;
            _provider = provider;
        }

        public async Task<IEnumerable<string>> Handle(FindMatchingTitles request, CancellationToken cancellationToken)
        {
            var systemTitle = await _dataStore.Games.SingleAsync(st => st.Id == request.Id, cancellationToken);

            return await _provider.FindCoverArtThumbnails(systemTitle.Title.Name);
        }
    }
}