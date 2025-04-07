public static class CacheKeys
{
    public static string OrdersByCustomer(int customerId) => $"OrdersByCustomer:{customerId}";
}