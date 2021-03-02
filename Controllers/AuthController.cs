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
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        public AuthController(HomeSewaDbContext dbContext)
        {
            _authService = new AuthService(dbContext);
        }

        [HttpPost]
        [Route("AuthorizeCustomer")]
        public IActionResult AuthorizeCustomer([FromBody] AuthModel authModel)
        {
            return Ok(_authService.AuthorizeCustomer(authModel));
        } 

        [HttpPost]
        [Route("AuthorizeVendor")]
        public IActionResult AuthorizeVendor([FromBody] AuthModel authModel)
        {
            return Ok(_authService.AuthorizeVendor(authModel));
        }
    }
}
