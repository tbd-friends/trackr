using System;
using MediatR;

namespace handlers.Commands
{
    public class CreateNewTitle : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}