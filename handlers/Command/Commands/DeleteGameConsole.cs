using System;
using MediatR;

namespace handlers.Commands
{
    public class DeleteGameConsole : IRequest
    {
        public Guid SystemId { get; set; }
    }
}