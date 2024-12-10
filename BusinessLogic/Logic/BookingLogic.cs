using BusinessLogic.Interfaces;
using BusinessLogic.Util;
using DTOs;
using Entities;
using RepositoryContracts;

namespace BusinessLogic.Logic;

public class BookingLogic : IBookingLogic
{
    private readonly IBookingRepository bookingRepository;
    private readonly IResourceRepository resourceRepository;

    public BookingLogic(IBookingRepository bookingRepository, IResourceRepository resourceRepository)
    {
        this.bookingRepository = bookingRepository;
        this.resourceRepository = resourceRepository;
    }
    
    public async Task<CreateBookingDto> CreateBookingAsync(CreateBookingDto request)
    {
        BookingHelper.ValidateBooking(request);
        
        var resource = await resourceRepository.GetResourceByIdAsync(request.ResourceId);
        if (resource == null)
        {
            throw new Exception("Resource not found");
        }

        var existingBookings = await bookingRepository.GetBookingsByResourceIdAsync(request.ResourceId);
        int bookedQuantity = BookingHelper.CalculateBookedQuantity(existingBookings, request.DateFrom, request.DateTo);

        if (request.BookedQuantity > (resource.Quantity - bookedQuantity))
        {
            throw new Exception("The quantity is not available for requested period.");
        }

        if (BookingHelper.IsConflict(existingBookings, request.DateFrom, request.DateTo, bookedQuantity, resource.Quantity))
        {
            throw new Exception("There is a conflict between bookings in requested period.");
        }

        var newBooking = new Booking
        {
            ResourceId = request.ResourceId,
            BookedQuantity = request.BookedQuantity,
            DateFrom = request.DateFrom,
            DateTo = request.DateTo
        };

        var createdBooking = await bookingRepository.AddAsync(newBooking);
        Console.WriteLine($"EMAIL SENT TO admin@admin.com FOR CREATED BOOKING WITH ID {createdBooking.Id}");

        return new CreateBookingDto
        {
            DateFrom = createdBooking.DateFrom,
            DateTo = createdBooking.DateTo,
            BookedQuantity = createdBooking.BookedQuantity,
            ResourceId = createdBooking.ResourceId
        };
    }
    
}