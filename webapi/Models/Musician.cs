using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class Musician
    {
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User? User{get;set;}
        public string ProfileInstruments { get; set; }
        public int YearsOfExperience { get; set; }
        public string StatusOfActivity { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public List<Band> Bands { get; set; }
        public List<MusicianBand> MusicianWrapper { get; set; } = new();
        public List<Band> FoundedBands { get; set; }
    }
}
