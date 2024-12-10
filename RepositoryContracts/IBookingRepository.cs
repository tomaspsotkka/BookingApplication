using Entities;

namespace RepositoryContracts;

public interface IBookingRepository
{
    Task<Booking> AddAsync(Booking booking);
    Task<bool> IsResourceAvailableAsync(int resourceId, DateOnly dateFrom, DateOnly dateTo, int quantity);
}