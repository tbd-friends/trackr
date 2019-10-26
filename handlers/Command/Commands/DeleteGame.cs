using System;
using MediatR;

namespace handlers.Commands
{
    public class DeleteGame : IRequest
    {
        public Guid GameId { get; set; }
    }
}