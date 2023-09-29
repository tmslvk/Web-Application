namespace webapi.Models
{
    public class Band
    {
        public int Id { get; set; } 
        public string NameOfBand { get; set; }
        public DateTime DateOfFoundation { get; set; }
        public string StatusOfActivity { get; set; }
        public List<Musician> MusicianList { get; set;}
        public List<Concert> ConcertList { get; set;}
        public List<MusicianBand> BandsWrapper { get; set; } = new();
    }
}
