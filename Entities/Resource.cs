namespace Entities;

public class Resource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }

    
    public Resource(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }

    private Resource(){}
}