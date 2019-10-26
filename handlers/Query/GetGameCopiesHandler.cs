using handlers.Queries;
using MediatR;
using persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using viewmodels;

namespace handlers
{
    public class GetGameCopiesHandler : IRequestHandler<GetGameCopies, IEnumerable<GameCopyViewModel>>
    {
        private readonly GamesContext _dataStore;

        public GetGameCopiesHandler(GamesContext dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task<IEnumerable<GameCopyViewModel>> Handle(GetGameCopies request, CancellationToken cancellationToken)
        {
            var gameCopies = from gc in _dataStore.GameCopies
                             where gc.GameId == request.Id
                             select new GameCopyViewModel()
                             {
                                 PurchasedOn = gc.PurchasedOn,
                                 PricePaid = gc.PricePaid,
                                 Tags = gc.Tags.Select(a => a.Tag.Value).OrderBy(s => s)
                             };

            return await Task.FromResult(gameCopies);
        }
    }
}