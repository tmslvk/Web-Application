using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using webapi.DTO;
using webapi.Models;

namespace webapi.Services
{
    public class BandService
    {
        UserContext db;

        public BandService(UserContext context)
        {
            this.db = context;
        }

        public async Task<Band> Add(BandDto bandsDto, Musician owner)
        {

            var band = new Band()
            {
                Name = bandsDto.Name,
                IsActive = bandsDto.IsActive,
                DateOfFoundation = bandsDto.DateOfFoundation,
                //MusicianList = bandsDto.MusicianList,
                //ConcertList = bandsDto.ConcertList,
                //MusicianBandList = new List<MusicianBand>() { bandsDto.BandFounder },
                Founder = owner
            };

            await db.Bands.AddAsync(band);
            await db.SaveChangesAsync();

            return band;
        }

        public async Task<Band?> GetBand(int id)
        {
            var band = await db.Bands.FirstOrDefaultAsync(band => band.Id == id);
            return band;
        }
    }
}
