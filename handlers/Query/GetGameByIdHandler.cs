using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using handlers.Queries;
using MediatR;
using persistence;
using viewmodels;

namespace handlers
{
    public class GetGameByIdHandler : IRequestHandler<GetGameById, GameTitleViewModel>
    {
        private readonly GamesContext _dataStore;

        public GetGameByIdHandler(GamesContext dataStore)
        {
            _dataStore = dataStore;
        }

        public Task<GameTitleViewModel> Handle(GetGameById request, CancellationToken cancellationToken)
        {
            var game = (from st in _dataStore.Games
                                 where st.Id == request.Id
                                 select new GameTitleViewModel
                                 {
                                     Name = st.Title.Name,
                                     Console = st.GameConsole.Name,
                                     YearOfRelease = st.ReleaseYear,
                                     CoverArtUrl = st.CoverArtUrl,
                                     IsWanted = st.IsWanted
                                 }).Single();

            return Task.FromResult(game);
        }
    }
}