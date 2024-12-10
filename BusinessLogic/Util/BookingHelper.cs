using DTOs;
using Entities;

namespace BusinessLogic.Util;

public class BookingHelper
{
    public static bool IsConflict(IEnumerable<Booking> existingBookings, DateOnly requestedStart, DateOnly requestedEnd, int bookedQuantityDuringPeriod, int resourceQuantity)
    {
        if (requestedStart < DateOnly.FromDateTime(DateTime.Now))
        {
            throw new Exception("Booking cannot start before the current day.");
        }
        int availableQuantity = resourceQuantity - bookedQuantityDuringPeriod;
        return existingBookings.Any(b => !(requestedStart > b.DateTo || requestedEnd < b.DateFrom) && availableQuantity <= 0);
    }
    
    public static void ValidateBooking(CreateBookingDto booking)
    {
        if (booking.ResourceId <= 0)
        {
            throw new Exception("Invalid Resource ID.");
        }

        if (booking.BookedQuantity <= 0)
        {
            throw new Exception("Booked quantity must be greater than zero.");
        }

        if (booking.DateFrom >= booking.DateTo)
        {
            throw new Exception("Invalid date range.");
        }
    }
    
    public static int CalculateBookedQuantity(IEnumerable<Booking> bookings, DateOnly dateFrom, DateOnly dateTo)
    {
        return bookings
            .Where(b => !(b.DateFrom > dateTo || b.DateTo < dateFrom))
            .Sum(b => b.BookedQuantity);
    }
}