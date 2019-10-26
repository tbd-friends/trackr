using System.Collections.Generic;
using MediatR;

namespace handlers.Queries
{
    public class GetTags : IRequest<IEnumerable<string>>
    {
        
    }
}