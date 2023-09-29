using webapi.Models;

namespace webapi.DTO
{
    public class ConcertDto
    {
        public string ConcertName { get; set; }
        public string ConcertDescription { get; set; }
        public DateTime ConcertDate { get; set; }
        public string ConcertPlace { get; set; }
        public List<Band> ConcertBandList { get; set; }
        public string AgeLimit { get; set; }
    }
}
