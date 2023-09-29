using Microsoft.EntityFrameworkCore;
using webapi.DTO;
using webapi.Models;

namespace webapi.Services
{
    public class ConcertService
    {
        UserContext db;

        public ConcertService(UserContext context)
        {
            this.db = context;
        }

        public async Task<Concert> Add(ConcertDto concertDto)
        {
            var concert = new Concert()
            {
                AgeLimit = concertDto.AgeLimit,
                ConcertDate = concertDto.ConcertDate,
                ConcertBandList = concertDto.ConcertBandList,
                ConcertDescription = concertDto.ConcertDescription,
                ConcertName = concertDto.ConcertName,
                ConcertPlace = concertDto.ConcertPlace,
            };

            await db.Concerts.AddAsync(concert);
            await db.SaveChangesAsync();

            return concert;
        }

        public async Task<Concert?> GetConcert(int id) 
        {
            return await db.Concerts.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
