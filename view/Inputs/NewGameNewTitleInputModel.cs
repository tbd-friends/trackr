using System;

namespace view.Inputs
{
    public class NewGameNewTitleInputModel
    {
        public Guid GameConsoleId { get; set; }
        public string Title { get; set; }
        public short? YearOfRelease { get; set; }
    }
}