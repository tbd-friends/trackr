using System;
using System.Collections.Generic;
using MediatR;
using viewmodels;

namespace handlers.Queries
{
    public class GetGames : IRequest<IEnumerable<GameViewModel>>
    {
    }
}