namespace DTOs;

public class ResourceDto
{
    public string? Name { get; set; }
    public int? Quantity { get; set; }

    public ResourceDto(string? name, int? quantity)
    {
        Name = name;
        Quantity = quantity;
    }
}