using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using handlers.Queries;
using handlers.Settings;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using persistence;
using viewmodels;

namespace handlers
{
    public class SearchAllGamesHandler : IRequestHandler<SearchAllGames, IEnumerable<SearchResultViewModel>>
    {
        private readonly GamesContext _dataStore;
        private readonly IConfiguration _configuration;
        private readonly int MaximumSearchItems;

        public SearchAllGamesHandler(GamesContext dataStore, IOptions<SearchSettings> options)
        {
            _dataStore = dataStore;

            MaximumSearchItems = options.Value.MaximumItems;
        }

        public Task<IEnumerable<SearchResultViewModel>> Handle(SearchAllGames request, CancellationToken cancellationToken)
        {
            var allGamesMatching = (from x in _dataStore.Games
                                    let matchTitle = (request.Text == null || request.Text == string.Empty) || (
                                                         x.Title.Name.Contains(request.Text) ||
                                                         x.GameConsole.Name.Contains(request.Text) ||
                                                         x.GameConsole.Manufacturer.Contains(request.Text))
                                    let copies = _dataStore.GameCopies.Count(gc => gc.GameId == x.Id)
                                    where matchTitle && (!request.IncludeOnlyWanted || x.IsWanted) &&
                                          (!request.IncludeWithCopies || copies > 0)
                                    orderby x.Title.Name, x.GameConsole.Manufacturer
                                    select new SearchResultViewModel()
                                    {
                                        GameId = x.Id,
                                        Title = $"{x.Title.Name}",
                                        GameConsole = $"{x.GameConsole.Manufacturer} {x.GameConsole.Name}",
                                        Count = copies,
                                        CoverArtUrl = x.CoverArtUrl,
                                        IsWanted = x.IsWanted
                                    }).Take(MaximumSearchItems).ToList();

            return Task.FromResult<IEnumerable<SearchResultViewModel>>(allGamesMatching);
        }
    }
}