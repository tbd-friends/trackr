using System;
using MediatR;

namespace handlers.Commands
{
    public class DeleteCoverArt : IRequest
    {
        public Guid Id { get; set; }
    }
}