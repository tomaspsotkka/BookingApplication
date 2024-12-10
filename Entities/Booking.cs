namespace Entities;

public class Booking
{
    public int Id { get; set; } //PK
    public DateOnly DateFrom { get; set; }
    public DateOnly DateTo { get; set; }
    public int BookedQuantity { get; set; }
    public int ResourceId { get; set; } //FK
    public Resource Resource { get; set; } //nav property 

    
    public Booking(DateOnly dateFrom, DateOnly dateTo, int bookedQuantity, int resourceId)
    {
        DateFrom = dateFrom;
        DateTo = dateTo;
        BookedQuantity = bookedQuantity;
        ResourceId = resourceId;
    }

    private Booking(){}
}