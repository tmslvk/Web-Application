using Microsoft.EntityFrameworkCore;
using webapi.DTO;
using webapi.Models;

namespace webapi.Services
{
    public class BandConcertService
    {
        UserContext db;

        public BandConcertService(UserContext context)
        {
            this.db = context;
        }

        public async Task<BandConcert> GetBandSpectators(bool spectatorsAnswer, int id)
        {
            var bandConcert = await db.BandConcerts.FirstOrDefaultAsync(x => x.Id == id);

            if(bandConcert == null) 
            {
                throw new ArgumentNullException(nameof(bandConcert));
            }
            if (spectatorsAnswer)
            {
                bandConcert.NumberOfVisitors += 1;
            }
            bandConcert.NumberOfVisitors -= 1;
            return bandConcert;
        }

        public async Task<List<BandConcert>> GetBandConcertList(int id)
        {
            return await db.BandConcerts.Where(u => u.BandID == id).ToListAsync();
        }

        public async Task<BandConcert?> AcceptRequest(int id)
        {
            return await db.BandConcerts.FirstOrDefaultAsync(u => !u.ConfirmationRequest && u.BandID == id);
        }

        public async void DeclineRequest(int id)
        {
            var band = await db.BandConcerts.FirstOrDefaultAsync(u => u.ConfirmationRequest && u.BandID == id);
            if (band != null)
            {
                db.Remove(band);
                db.SaveChanges();
            }
            return;
        }
    }
}
