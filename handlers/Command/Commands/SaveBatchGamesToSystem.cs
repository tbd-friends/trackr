using System;
using MediatR;

namespace handlers.Commands
{
    public class SaveBatchGamesToSystem : IRequest
    {
        public Guid SystemId { get; set; }
        public string Titles { get; set; }
    }
}