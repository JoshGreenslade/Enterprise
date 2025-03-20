namespace Chap3.Domain;

public class Order
{
    public int Id { get; set; }
    
    public int CustomerId { get; set; } 
    public Customer Customer { get; set; }
    
    public ICollection<OrderItem> OrderItems { get; set; }
}