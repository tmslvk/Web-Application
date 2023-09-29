using webapi.Models;

namespace webapi.DTO
{
    public class MusicianInBandDto
    {
        public int MusicianId { get; set; }
        public Musician? MusicianWrap { get; set; }
        public int BandID { get; set; }
        public Band? BandWrap { get; set; }
        public string Role { get; set; }
        public DateTime ParticiapationDateFrom { get; set; }
        public DateTime ParticiapationDateTo { get; set; }
        public bool ConfirmationOfRequest { get; set; }
    }
}
