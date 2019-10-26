using System;
using MediatR;

namespace handlers.Commands
{
    public class SetCoverArtForGame : IRequest
    {
        public Guid GameId { get; set; }
        public string CoverArtUrl { get; set; }
    }
}