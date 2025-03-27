namespace Chap3.Domain;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    private readonly List<OrderItem> _orderItems = new();
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

    public void AddProduct(Product product, int quantity)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));

        var existing = _orderItems.FirstOrDefault(x => x.ProductId == product.Id);
        if (existing != null) throw new ArgumentException();
        _orderItems.Add(new OrderItem { ProductId = product.Id, Quantity = quantity });
    }
}