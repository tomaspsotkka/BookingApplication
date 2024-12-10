using BusinessLogic.Interfaces;
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
        bool isAvailable = await bookingRepository.IsResourceAvailableAsync(request.ResourceId, request.DateFrom,
            request.DateTo, request.BookedQuantity);

        if (!isAvailable)
        {
            throw new InvalidOperationException("Requested quantity is not available for the requested period.");
        }
        
        Booking booking = new(request.DateFrom, request.DateTo, request.BookedQuantity, request.ResourceId);
        Booking created = await bookingRepository.AddAsync(booking);
        
        return new CreateBookingDto
        {
            DateFrom = created.DateFrom,
            DateTo = created.DateTo,
            BookedQuantity = created.BookedQuantity,
            ResourceId = created.ResourceId
        };
    }
}