namespace webapi.Models
{
    public class BandConcert
    {
        public int Id { get; set; }
        public int NumberOfVisitors { get; set; }
        public int BandID { get; set; }
        public Band? BandWrap { get; set; }
        public int ConcertId { get; set; }
        public Concert? ConcertWrap { get; set; }
        public bool ConfirmationRequest { get; set; }
    }
}
