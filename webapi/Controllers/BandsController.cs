using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public BandsController(IConfiguration configuration, BandService bandService)
        {
            _configuration = configuration;
            this.bandService = bandService;
        }

        [HttpPost]
        public async Task<ActionResult<Band>> AddBand(BandsDto request)
        {
            var band = await bandService.Add(request);

            return Created("", band);
        }
    }
}
