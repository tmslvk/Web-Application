using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Security.Claims;
using webapi.DTO;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers
{
    [Route("api/musician-bands")]
    [ApiController]
    [Authorize]
    public class MusicianBandsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        MusicianService musicianService;
        BandService bandService;
        MusicianBandService musicianBandService;

        public MusicianBandsController(IConfiguration configuration,BandService bandService, MusicianService musicianService, MusicianBandService musicianBandService)
        {
            this.musicianService = musicianService;
            _configuration = configuration;
            this.musicianBandService = musicianBandService;
            this.bandService = bandService;
        }

        [HttpPost]
        public async Task<ActionResult<MusicianBand>> AddMusicianToBand(MusicianInBandDto musicianInBandDto)
        {
            try
            {
                var musician = await musicianService.GetMusician(musicianInBandDto.MusicianId);
                if(musician == null)
                {
                    throw new Exception("Musician is null");
                }
                //var band
                MusicianBand musicianInBand = new MusicianBand()
                {
                    BandID = musicianInBandDto.BandID,
                    MusicianId = musicianInBandDto.MusicianId,
                    MusicianWrap = musician, //musician
                    BandWrap = musicianInBandDto.BandWrap, //band
                    Role = musicianInBandDto.Role,
                    ParticiapationDateTo = musicianInBandDto.ParticiapationDateTo,
                    ParticiapationDateFrom = musicianInBandDto.ParticiapationDateFrom,
                };

                return Created("", musicianInBand);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("musician-requests")]
        public async Task<ActionResult<MusicianBand>> GetRequest()
        {
            var id = HttpContext.User.Claims.First(claim => claim.Type == ClaimTypes.UserData).Value;
            if(id == string.Empty)
            {
                return BadRequest("User is not a musician");
            }
            var requests = await musicianBandService.GetAllRequest(int.Parse(id));
            return Ok(requests);
        }

        [HttpPut("request-to-musician")]
        public async Task<ActionResult<List<MusicianBand>>> SendRequest(MusicianBand musicianBand)
        {
            var musician = await musicianService.GetMusician(musicianBand.MusicianId);
            var band = await bandService.GetBand(musicianBand.BandID);

            MusicianInBandDto request = new MusicianInBandDto()
            {
                BandID = musicianBand.BandID,
                ParticiapationDateFrom = musicianBand.ParticiapationDateFrom,
                ParticiapationDateTo = musicianBand.ParticiapationDateTo,
                BandWrap = band,
                MusicianId = musicianBand.MusicianId,
                MusicianWrap = musician,
                Role = musicianBand.Role,
                ConfirmationOfRequest = false,
            };
            return Ok(request);
        }

        [HttpGet("answer")]
        public async Task<ActionResult<MusicianBand>> AnswerRequest(MusicianBand musicianBand)
        {
            bool isConfirmed = musicianBand.ConfirmationRequest;
            if (isConfirmed)
            {
                var musician = await musicianBandService.AcceptRequest(musicianBand.Id);
                return Ok(musician);
            }
            musicianBandService.DeclineRequest(musicianBand.Id);
            return NoContent();
        }
    }
}
