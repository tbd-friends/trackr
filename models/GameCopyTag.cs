using System;

namespace models
{
    public class GameCopyTag
    {
        public Guid Id { get; set; }
        public Guid GameCopyId { get; set; }
        public Guid TagId { get; set; }

        public virtual GameCopy GameCopy { get; set; }
        public virtual Tag Tag { get; set; }
    }
}