using webapi.Models;

namespace webapi.DTO
{
    public class MusicianDto : MusicianFormDto
    {
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
