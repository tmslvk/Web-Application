using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.DTO;

namespace webapi.Models
{
    public class MusicianService
    {
        UserContext db;

        public MusicianService(UserContext context)
        {
            this.db = context;
        }

        public async Task<Musician> Add(MusicianDto musicianDto)
        {
            var musician = new Musician()
            {
                YearsOfExperience = musicianDto.YearsOfExperience,
                StatusOfActivity = musicianDto.StatusOfActivity,
                ProfileInstruments = musicianDto.ProfileInstruments,
                Country = musicianDto.Country,
                City = musicianDto.City,
                User = musicianDto.User,
            };

            await db.Musicians.AddAsync(musician);
            await db.SaveChangesAsync();

            return musician;
        }

        public async Task<Musician?> GetMusician(int id)
        {
            var musician = await db.Musicians.FirstOrDefaultAsync(u => u.Id == id);
            return musician;
        }

        public async Task<Musician?> GetMusicianByUserId(int userId)
        {
            var musician = await db.Musicians.FirstOrDefaultAsync(m => m.UserId == userId);
            return musician;
        }

        //public async Task<List<Musician>> GetAllMusicianByRole(MusicianBand musicianBand)
        //{
        //    return await db.Musicians.Where(u => u.ProfileInstruments == musicianBand.Role).ToListAsync();
        //}
    }
}
