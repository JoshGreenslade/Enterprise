namespace Chap3.Domain;

public class Customer
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public Customer(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));
        Name = name;
    }
}