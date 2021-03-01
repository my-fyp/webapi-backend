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
    public class BookingController : ControllerBase
    {
        private readonly BookingService bookingService;
        public BookingController(HomeSewaDbContext DbContext)
        {
            bookingService = new BookingService(DbContext);
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(BookingService.GetAllBooking());
        }

    }
}
