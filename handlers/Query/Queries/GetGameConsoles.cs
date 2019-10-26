using System.Collections.Generic;
using MediatR;
using viewmodels;

namespace handlers.Queries
{
    public class GetGameConsoles : IRequest<IEnumerable<GameConsoleViewModel>>
    {
        
    }
}