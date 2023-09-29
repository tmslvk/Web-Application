namespace webapi.Models
{
    public class MusicianBand
    {
        public int Id { get; set; }
        public int MusicianId { get; set; }
        public Musician MusicianWrap { get; set; }
        public int BandID { get; set; }
        public Band? BandWrap { get; set; }
        public string Role { get; set; }
        public DateTime ParticiapationDateFrom { get; set; }
        public DateTime ParticiapationDateTo { get; set; }
        public bool ConfirmationRequest { get; set; }
    }
}
