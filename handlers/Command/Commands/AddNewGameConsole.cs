using MediatR;

namespace handlers.Commands
{
    public class AddNewGameConsole : IRequest
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public short? YearOfRelease { get; set; }
    }
}