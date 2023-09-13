using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicianController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        MusicianService musicianService;
        UserService userService;

        public MusicianController(IConfiguration configuration, MusicianService musicianService, UserService userService)
        {
            this.musicianService = musicianService;
            _configuration = configuration;
            this.userService = userService;
        }
        [HttpPost("AddMusician")]
        [Authorize]
        public async Task<ActionResult<Musician>> AddMusician(MusicianDto musicianDto)
        {
            var userContext = HttpContext.User;
            int userID = int.Parse(userContext.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);

            Musician musician = await musicianService.Add(musicianDto);
                
            User? updatedUser = await userService.LinkMusician(userID, musician);

            return musician;
        }
    }
}
