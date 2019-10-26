using System;
using System.Collections;
using System.Collections.Generic;
using MediatR;
using viewmodels;

namespace handlers.Queries
{
    public class GetGameCopies : IRequest<IEnumerable<GameCopyViewModel>>
    {
        public Guid Id { get; set; }
    }
}