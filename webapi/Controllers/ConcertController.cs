using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.DTO;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers
{
    [Route("api/concerts")]
    [ApiController]
    [Authorize]
    public class ConcertController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        ConcertService concertService;


        public ConcertController(IConfiguration configuration, ConcertService concertService)
        {
            _configuration = configuration;
            this.concertService = concertService;
        }

        [HttpPost]
        public async Task<ActionResult<Band>> AddBand(ConcertDto request)
        {
            var band = await concertService.Add(request);

            return Created("", band);
        }
    }
}
