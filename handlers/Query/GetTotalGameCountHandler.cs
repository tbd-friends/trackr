using System.Threading;
using System.Threading.Tasks;
using handlers.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using persistence;

namespace handlers
{
    public class GetTotalGameCountHandler : IRequestHandler<GetTotalGameCount, int>
    {
        private readonly GamesContext _dataStore;

        public GetTotalGameCountHandler(GamesContext dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task<int> Handle(GetTotalGameCount request, CancellationToken cancellationToken)
        {
            return await _dataStore.Games.CountAsync(cancellationToken);
        }
    }
}