namespace viewmodels
{
    public class GameTitleViewModel
    {
        public string Name { get; set; }
        public string Console { get; set; }
        public short? YearOfRelease { get; set; }
        public string CoverArtUrl { get; set; }
        public bool IsWanted { get; set; }
    }
}