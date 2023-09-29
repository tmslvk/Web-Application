using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using webapi.DTO;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/musicians")]
    [ApiController]
    [Authorize]
    public class MusicianController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        MusicianService musicianService;
        UserService userService;
        UserContext db;

        public MusicianController(IConfiguration configuration, MusicianService musicianService, UserService userService)
        {
            this.musicianService = musicianService;
            _configuration = configuration;
            this.userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<Musician>> AddMusician(MusicianFormDto musicianFormDto)
        {
            var userContext = HttpContext.User;
            int userID = int.Parse(userContext.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
            var user = await userService.GetOne(userID);
            
            MusicianDto musicianDto = new MusicianDto() 
            {
                User = user,
                UserId = userID,
                City = musicianFormDto.City,
                Country = musicianFormDto.Country,
                YearsOfExperience = musicianFormDto.YearsOfExperience,
                StatusOfActivity = musicianFormDto.StatusOfActivity,
                ProfileInstruments = musicianFormDto.ProfileInstruments,
            };
            
            Musician musician = await musicianService.Add(musicianDto);

            return musician;
        }
    }
}
