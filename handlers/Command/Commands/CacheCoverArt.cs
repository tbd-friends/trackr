using System;
using MediatR;

namespace handlers.Commands
{
    public class CacheCoverArt : IRequest<string>
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
    }
}