namespace Chap3.Domain;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal UnitPrice { get; set; }
}