using Home_Sewa.Data;
using Home_Sewa.Helper;
using Home_Sewa.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly RegisterService userRegister;

        public RegisterController(HomeSewaDbContext dbContext)
        {
            userRegister = new RegisterService(dbContext);
        }
        [HttpPost]
        [Route("RegisterUser")]
        public IActionResult RegisterUser([FromBody] RegisterUser user_model)
        {
            return Ok(userRegister.RegisterUser(user_model));
        }
    }
}
