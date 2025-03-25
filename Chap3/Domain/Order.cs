namespace Chap3.Domain;

public class Order
{
    public int Id { get; set; }
    public string CustomerId { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}