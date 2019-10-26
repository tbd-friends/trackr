using System;

namespace models
{
    public class GameConsole
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public short? ReleaseYear { get; set; }
    }
}