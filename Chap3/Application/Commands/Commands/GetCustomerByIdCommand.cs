public class GetCustomerByIdCommand
{
    public int Id { get; private set; }

    public GetCustomerByIdCommand(int id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));
        Id = id;
    }
}