using Entities;
using Microsoft.EntityFrameworkCore;

namespace EfcRepositories;

public class AppContext : DbContext
{
    public DbSet<Resource> Resources => Set<Resource>();
    public DbSet<Booking> Bookings => Set<Booking>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source = C:\Users\psotk\RiderProjects\BookingApplication\EfcRepositories\bookingApp.db"); 
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>().HasKey(b => b.Id);
        modelBuilder.Entity<Booking>().Property(b => b.DateFrom).IsRequired();
        modelBuilder.Entity<Booking>().Property(b => b.DateTo).IsRequired();
        modelBuilder.Entity<Booking>().Property(b => b.BookedQuantity).IsRequired();
        modelBuilder.Entity<Booking>().HasOne(b => b.Resource).WithMany()
            .HasForeignKey(b => b.ResourceId);
        modelBuilder.Entity<Resource>().HasKey(r => r.Id);
        modelBuilder.Entity<Resource>().Property(r => r.Name).IsRequired();
        modelBuilder.Entity<Resource>().Property(r => r.Quantity).IsRequired();
    }
}