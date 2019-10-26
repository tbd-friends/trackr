using System;
using System.Collections;
using System.Collections.Generic;
using MediatR;
using viewmodels;

namespace handlers.Queries
{
    public class FindMatchingTitles : IRequest<IEnumerable<string>>
    {
        public Guid Id { get; set; }
    }
}