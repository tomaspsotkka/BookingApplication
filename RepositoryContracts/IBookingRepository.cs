using Entities;

namespace RepositoryContracts;

public interface IBookingRepository
{
    Task<Booking> AddAsync(Booking booking);
    Task<IEnumerable<Booking>> GetBookingsByResourceIdAsync(int resourceId);
    
}