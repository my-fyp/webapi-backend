using Home_Sewa.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Service
{
    public class BookingService
    {
        private readonly HomeSewaDbContext _DbContext;

        public BookingService(HomeSewaDbContext Db)
        {
            _DbContext = Db;

        }
        internal object GetAllBooking()
        {
            return _DbContext.Bookings;
        }
    }
}
