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
    public class BookingController : ControllerBase
    {
        private readonly BookingService bookingService;
        public BookingController(HomeSewaDbContext DbContext)
        {
            bookingService = new BookingService(DbContext);
        }
        [HttpGet]
        [Route("GetBookings/{userId}/{userType}/{completedStatus}")]
        public IActionResult GetBookings(int userId, string userType, bool completedStatus)
        {
            return Ok(bookingService.GetAllBooking(userId, userType, completedStatus));
        }
        
        [HttpGet]
        [Route("GetBookingRequests/{userId}/{userType}")]
        public IActionResult GetBookingRequests(int userId, string userType)
        {
            return Ok(bookingService.GetBookingRequests(userId, userType));
        }


        [HttpPost]
        [Route("MakeBookingRequest")]
        public IActionResult MakeBookingRequest([FromBody] BookingRequest bookingRequest)
        {
            return Ok(bookingService.MakeBookingRequest(bookingRequest));
        }

        [HttpPatch]
        [Route("UpdateBooking/{bookingId}")]
        public IActionResult UpdateBooking(int bookingId, [FromBody] BookingRequest newDetails)
        {
            return Ok(bookingService.UpdateBooking(bookingId, newDetails));
        }

        [HttpDelete]
        [Route("CancelBooking/{bookingId}")]
        public IActionResult CancelBooking(int bookingId)
        {
            return Ok(bookingService.CancelBooking(bookingId));
        }
    }
}




