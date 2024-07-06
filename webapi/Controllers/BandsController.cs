using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using webapi.DTO;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers
{
    [Route("api/bands")]
    [ApiController]
    [Authorize]
    public class BandsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        BandService bandService;
        MusicianService musicianService;
        UserService userService;
        MusicianBandService musicianBandService;
        public BandsController(IConfiguration configuration, BandService bandService, MusicianService musicianService, UserService userService, MusicianBandService musicianBandService)
        {
            _configuration = configuration;
            this.bandService = bandService;
            this.musicianService = musicianService;
            this.userService = userService;
            this.musicianBandService = musicianBandService;
        }

        [HttpPost]
        public async Task<ActionResult<Band>> AddBand(AddBandDto request)
        {
            var userContext = HttpContext.User;
            int userID = int.Parse(userContext.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
            var musician = await musicianService.GetMusicianByUserId(userID);
            
            if(musician != null)
            {
                BandDto bandDto = new BandDto()
                {
                    DateOfFoundation = request.DateOfFoundation,
                    IsActive = request.IsActive,
                    Name = request.Name,
                    //ConcertList = new List<Concert>(),
                    //MusicianList = new List<Musician>() { musician },

                };
                
                Band band = await bandService.Add(bandDto, musician);
                return Created("", band);
            }
            return BadRequest();
        }

        //[HttpPost("band-founder")]
        //public async Task<ActionResult<MusicianBand>> AddFounder([FromQuery]Band band, Musician musician)
        //{
        //    MusicianInBandDto musicianInBandDto = new MusicianInBandDto()
        //    {
        //        BandID = band.Id,
        //        ParticiapationDateFrom = band.DateOfFoundation,
        //        MusicianId = musician.Id,
        //        MusicianWrap = musician,
        //        BandWrap = band,
        //        ConfirmationOfRequest = true,
        //        Role = "Founder",
        //        ParticiapationDateTo = DateTime.Now,
        //    };

        //    var musicianInBand = await musicianBandService.AddFounderToBand(musicianInBandDto);

        //    return musicianInBand;
        //}
    }
}
