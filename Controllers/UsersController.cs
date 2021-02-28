using Home_Sewa.Data;
using Home_Sewa.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Home_Sewa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;
        public UsersController(HomeSewaDbContext dbContext)
        {
            _usersService = new UsersService(dbContext);
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usersService.GetAllUsers());
        }
    }
}
