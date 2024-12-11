using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RepositoryContracts;

namespace EfcRepositories;

public class EfcBookingRepository : IBookingRepository
{
    private readonly AppContext ctx;
    
    public EfcBookingRepository(AppContext ctx)
    {
        this.ctx = ctx;
    }
    
    public async Task<Booking> AddAsync(Booking booking)
    {
        EntityEntry<Booking> entityEntry = await ctx.Bookings.AddAsync(booking);
        await ctx.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public Task<IEnumerable<Booking>> GetBookingsByResourceIdAsync(int resourceId)
    {
        IQueryable<Booking> bookings = ctx.Bookings.AsQueryable();
        bookings = bookings.Where(b => b.ResourceId == resourceId);
        return Task.FromResult(bookings.AsEnumerable());
    }
}