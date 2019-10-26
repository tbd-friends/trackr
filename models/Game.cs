using System;

namespace models
{
    public class Game
    {
        public Guid Id { get; set; }
        public Guid GameConsoleId { get; set; }
        public Guid TitleId { get; set; }
        public short? ReleaseYear { get; set; }
        public string CoverArtUrl { get; set; }
        public bool IsWanted { get; set; }

        public virtual GameConsole GameConsole { get; set; }
        public virtual Title Title { get; set; }
    }
}
