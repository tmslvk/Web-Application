using webapi.Models;

namespace webapi.DTO
{
    public class AddBandDto
    {
        public string Name { get; set; }
        public DateTime DateOfFoundation { get; set; }
        public bool IsActive { get; set; }
    }
}
