using webapi.Models;

namespace webapi.DTO
{
    public class BandsDto
    {
        public string NameOfBand { get; set; }
        public DateTime DateOfFoundation { get; set; }
        public string StatusOfActivity { get; set; }
        public List<Musician> MusicianList { get; set; }
    }
}
