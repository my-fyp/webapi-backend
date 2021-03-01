using Home_Sewa.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Data
{
    public class HomeSewaDbContext : DbContext
    {
        public HomeSewaDbContext(DbContextOptions<HomeSewaDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<Favourite>Favourites { get; set; }
        public DbSet<Booking>Bookings { get; set; }
    }
}
