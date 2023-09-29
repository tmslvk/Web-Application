using webapi.Models;

namespace webapi.DTO
{
    public class BandConcertDto
    {
        public int NumberOfVisitors { get; set; }
        public int BandID { get; set; }
        public Band? BandWrap { get; set; }
        public int ConcertId { get; set; }
        public Concert? ConcertWrap { get; set; }

        public bool Confirmationequest { get; set; }
    }
}
