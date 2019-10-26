using System;
using MediatR;
using viewmodels;

namespace handlers.Queries
{
    public class GetGameById : IRequest<GameTitleViewModel>
    {
        public Guid Id { get; set; }
    }
}