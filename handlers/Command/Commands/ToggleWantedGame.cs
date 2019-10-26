using System;
using MediatR;

namespace handlers.Commands
{
    public class ToggleWantedGame : IRequest
    {
        public Guid GameId { get; set; }
    }
}