namespace DTOs;

public class CreateBookingDto
{
    public DateOnly DateFrom { get; set; }
    public DateOnly DateTo { get; set; }
    public int BookedQuantity { get; set; }
    public int ResourceId { get; set; }

    public CreateBookingDto(DateOnly dateFrom, DateOnly dateTo, int bookedQuantity, int resourceId)
    {
        DateFrom = dateFrom;
        DateTo = dateTo;
        BookedQuantity = bookedQuantity;
        ResourceId = resourceId;
    }

    public CreateBookingDto()
    {
    }
}