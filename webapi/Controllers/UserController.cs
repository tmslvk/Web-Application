using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using webapi.Models;

namespace webapi.Controllers
{
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        UserService service;
        public UserController(IConfiguration configuration, UserService userService) 
        {
            this.service = userService;
            _configuration = configuration;
        }
    }
}
