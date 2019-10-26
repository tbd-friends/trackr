using System;
using System.Dynamic;
using MediatR;

namespace handlers.Commands
{
    public class CreateGameUsingExistingTitle : IRequest
    {
        public Guid GameConsole { get; set; }
        public Guid Title { get; set; }
        public short? YearOfRelease { get; set; }
    }
}