using System;
using System.Collections;
using System.Collections.Generic;
using MediatR;

namespace handlers.Commands
{
    public class AddGameCopy : IRequest
    {
        public Guid GameId { get; set; }
        public DateTime? PurchasedOn { get; set; }
        public decimal? PricePaid { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}