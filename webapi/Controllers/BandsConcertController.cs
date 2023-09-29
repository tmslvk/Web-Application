using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using webapi.DTO;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers
{
    [Route("api/bands-concerts")]
    [ApiController]
    [Authorize]
    public class BandsConcertController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        BandService bandService;
        BandConcertService bandConcertService;
        ConcertService concertService;
        MusicianService musicianService;
        MusicianBandService musicianBandService;

        public BandsConcertController(IConfiguration configuration, BandService bandService, BandConcertService bandConcertService, ConcertService concertService, MusicianService musicianService, MusicianBandService musicianBandService)
        {
            _configuration = configuration;
            this.bandService = bandService;
            this.bandConcertService = bandConcertService;
            this.concertService = concertService;
            this.musicianService = musicianService;
            this.musicianBandService = musicianBandService;
        }

        public async Task<ActionResult<BandConcert>> Add(BandConcertDto bandDto, int BandId, int ConcertId)
        {
            try
            {
                var band = await bandService.GetBand(BandId);
                var concert = await concertService.GetConcert(ConcertId);
                if(band == null && concert == null) 
                {
                    throw new ArgumentNullException("Band and concert is null");
                }
                var bandConcert = new BandConcert()
                {
                    BandWrap = band,
                    ConcertWrap = concert,
                    ConcertId = bandDto.ConcertId,
                    BandID = bandDto.BandID,
                    NumberOfVisitors = bandDto.NumberOfVisitors,
                    ConfirmationRequest = bandDto.Confirmationequest,
                };

                return Created("", bandConcert);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("bands-requests")]
        public async Task<ActionResult<BandConcert>> GetRequest()
        {
            var musicianId = HttpContext.User.Claims.First(claim => claim.Type == ClaimTypes.UserData).Value;
            var musicianBand = await musicianBandService.GetBandByMusicianId(int.Parse(musicianId));

            if (musicianId == string.Empty)
            {
                return BadRequest("User is not a musician");
            }
            if(musicianBand == null)
            {
                return BadRequest("This band do not exist");
            }
            var requests = await bandConcertService.GetBandConcertList(musicianBand.BandID);
            return Ok(requests);
        }

        [HttpPost("request-to-band")]
        public async Task<ActionResult<List<BandConcert>>> SendRequest(BandConcert bandConcert)
        {
            var band = await bandService.GetBand(bandConcert.BandID);
            var concert = await concertService.GetConcert(bandConcert.BandID);
            BandConcertDto request = new BandConcertDto()
            {
                BandWrap = band,
                BandID = bandConcert.BandID,
                ConcertId = bandConcert.ConcertId,
                ConcertWrap = concert,
                Confirmationequest = bandConcert.ConfirmationRequest,
                NumberOfVisitors = bandConcert.NumberOfVisitors,
            };
            return Ok(request);
        }

        [HttpGet("answer-band")]
        public async Task<ActionResult<BandConcert>> AnswerRequest(BandConcert bandConcert)
        {
            bool isConfirmed = bandConcert.ConfirmationRequest;
            if (isConfirmed)
            {
                var bandAnswer = await bandConcertService.AcceptRequest(bandConcert.Id);
                return Ok(bandAnswer);
            }
            bandConcertService.DeclineRequest(bandConcert.Id);
            return NoContent();
        }
    }
}
