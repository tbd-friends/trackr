using System.Collections.Generic;
using MediatR;
using viewmodels;

namespace handlers.Queries
{
    public class GetTitles : IRequest<IEnumerable<TitleViewModel>>
    {
    }
}