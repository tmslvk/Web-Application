namespace webapi.Models
{
    public class Band
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public DateTime DateOfFoundation { get; set; }
        public bool IsActive { get; set; }
        public List<Musician> MusicianList { get; set; } = new();
        public List<Concert> ConcertList { get; set;} = new();
        public List<MusicianBand> MusicianBandList { get; set; } = new();
        public Musician? Founder { get; set; }
        public int? FounderId { get; set; }
    }
}
