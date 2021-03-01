using Home_Sewa.Data;
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
    public class OffersController : ControllerBase
    {
        private readonly OffersService offerServices;
        public OffersController(HomeSewaDbContext dbContext)
        {
           offerServices = new OffersService(dbContext);
        }
          [HttpGet]
            public IActionResult Get()
            {
                return Ok(offerServices.GetAllOffers());
            }
    }
}

