using System;
using System.Collections.Generic;

namespace view.Inputs
{
    public class AddGameCopyInputModel
    {
        public Guid GameId { get; set; }
        public DateTime? PurchasedOn { get; set; }
        public decimal? PricePaid { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}