using System.Collections.Generic;
using System.Threading.Tasks;
using handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace view.Controllers
{
    [ApiController]
    [Route("tags")]
    public class TagsController
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> GetTags()
        {
            return await _mediator.Send(new GetTags());
        }
    }
}