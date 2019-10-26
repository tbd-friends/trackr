using System;
using System.Collections;
using System.Collections.Generic;

namespace models
{
    public class GameCopy
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public decimal? PricePaid { get; set; }
        public DateTime? PurchasedOn { get; set; }

        public virtual ICollection<GameCopyTag> Tags { get; set; }
    }
}