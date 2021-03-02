using Home_Sewa.Model;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder _modelBuilder)
        {
            _modelBuilder.Entity<Booking>()
                .HasOne(b => b.Vendor)
                .WithMany(v => v.Bookings)
                .IsRequired()
                .HasForeignKey(b => b.VendorId)
                .OnDelete(DeleteBehavior.ClientCascade);

            _modelBuilder.Entity<Booking>()
                .HasOne(b => b.Customer)
                .WithMany(c => c.Bookings)
                .IsRequired()
                .HasForeignKey(b => b.CustomerId)
                .OnDelete(DeleteBehavior.ClientCascade);
            
            _modelBuilder.Entity<Favourite>()
                .HasOne(b => b.Vendor)
                .WithMany(v => v.Favourites)
                .IsRequired()
                .HasForeignKey(b => b.VendorId)
                .OnDelete(DeleteBehavior.ClientCascade);

            _modelBuilder.Entity<Favourite>()
                .HasOne(b => b.Customer)
                .WithMany(c => c.Favourites)
                .IsRequired()
                .HasForeignKey(b => b.CustomerId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
