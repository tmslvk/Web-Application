using Microsoft.EntityFrameworkCore;

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
            };

            await db.Musicians.AddAsync(musician);
            await db.SaveChangesAsync();

            return musician;
        }
    }
}
