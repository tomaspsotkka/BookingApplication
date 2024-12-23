namespace DTOs;

public class ResourceDto
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public int? Quantity { get; set; }

    
    public ResourceDto() {}
    public ResourceDto(string? name, int? quantity)
    {
        Name = name;
        Quantity = quantity;
    }
    
    public ResourceDto(int id, string? name, int? quantity)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
    }
}