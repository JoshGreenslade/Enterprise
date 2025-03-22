namespace Chap3.Domain;

public class Order
{
    public int Id { get; set; }

    public Customer Customer { get; set; }

    private readonly List<OrderItem> _orderItems = new();
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

    public Order(Customer customer)
    {
        ArgumentNullException.ThrowIfNull(customer);
        Customer = customer;
    }
}