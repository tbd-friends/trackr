using System;

namespace viewmodels
{
    public class SearchResultViewModel
    {
        public Guid GameId { get; set; }
        public string Title { get; set; }
        public string GameConsole { get; set; }
        public bool IsWanted { get; set; }
        public string CoverArtUrl { get; set; }
        public int Count { get; set; }
    }
}