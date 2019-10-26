using System;
using System.Collections.Generic;

namespace viewmodels
{
    public class GameCopyViewModel
    {
        public DateTime? PurchasedOn { get; set; }
        public decimal? PricePaid { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}