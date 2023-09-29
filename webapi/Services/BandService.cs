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

        public async Task<Band> Add(BandsDto bandsDto)
        {
            var band = new Band()
            {
                NameOfBand = bandsDto.NameOfBand,
                StatusOfActivity = bandsDto.StatusOfActivity,
                MusicianList = bandsDto.MusicianList,
                DateOfFoundation = bandsDto.DateOfFoundation,
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
