using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using view.Inputs;
using viewmodels;

namespace view.Controllers
{
    [ApiController]
    [Route("search")]
    public class SearchController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SearchController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IEnumerable<SearchResultViewModel>> SearchGames([FromQuery]SearchInputModel input)
        {
            return await _mediator.Send(new SearchAllGames()
            {
                Text = input.Query,
                IncludeOnlyWanted = input.IncludeOnlyWanted,
                IncludeWithCopies = input.IncludeWithCopies
            });
        }

        [HttpGet, Route("match/{id}")]
        public async Task<IEnumerable<string>> MatchGames(Guid id)
        {
            return await _mediator.Send(new FindMatchingTitles() { Id = id });
        }
    }
}