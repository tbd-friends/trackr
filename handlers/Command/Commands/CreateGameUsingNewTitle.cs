using System;
using MediatR;

namespace handlers.Commands
{
    public class CreateGameUsingNewTitle : IRequest
    {
        public Guid ConsoleId { get; set; }
        public string Name { get; set; }
        public short? YearOfRelease { get; set; }
    }
}