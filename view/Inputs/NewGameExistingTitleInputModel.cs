using System;

namespace view.Inputs
{
    public class NewGameExistingTitleInputModel
    {
        public Guid GameConsoleId { get; set; }
        public short? YearOfRelease { get; set; }
    }
}