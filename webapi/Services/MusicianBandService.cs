using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.CompilerServices;
using webapi.DTO;
using webapi.Models;

namespace webapi.Services
{
    public class MusicianBandService
    {
        UserContext db;

        public MusicianBandService(UserContext context)
        {
            this.db = context;
        }

        public async Task<List<MusicianBand>> GetAllRequest(int musicianId)
        {
            return await db.MusicianBands.Where(u => u.MusicianId == musicianId).ToListAsync();
        }

        public async Task<MusicianBand?> AcceptRequest(int id)
        {
            return await db.MusicianBands.FirstOrDefaultAsync(u => !u.ConfirmationRequest && u.MusicianId == id);
        }

        public async void DeclineRequest(int id)
        {
            var musician = await db.MusicianBands.FirstOrDefaultAsync(u => u.ConfirmationRequest && u.MusicianId == id);
            if(musician != null) 
            {
                db.Remove(musician);
                db.SaveChanges();
            }
            return;
        }

        public async Task<MusicianBand?> GetBandByMusicianId(int id)
        {
            return await db.MusicianBands.FirstOrDefaultAsync(mb => mb.MusicianId == id);
        }

        public async Task<MusicianBand> AddFounderToBand(MusicianInBandDto dto)
        {
            var musicianToBand = new MusicianBand()
            {
                BandID = dto.BandID,
                ParticiapationDateFrom = dto.ParticiapationDateFrom,
                ParticiapationDateTo = dto.ParticiapationDateTo,
                ConfirmationRequest = dto.ConfirmationOfRequest,
                BandWrap = dto.BandWrap,
                MusicianId = dto.MusicianId,
                MusicianWrap = dto.MusicianWrap,
                Role = dto.Role,                
            };

            await db.MusicianBands.AddAsync(musicianToBand);
            await db.SaveChangesAsync();

            return musicianToBand;
        }
    }
}
