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
    }
}
