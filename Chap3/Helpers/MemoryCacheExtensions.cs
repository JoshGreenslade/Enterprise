using Microsoft.Extensions.Caching.Memory;

public static class MemoryCacheExtensions
{
    public static void SetWithTimeout<T>(
        this IMemoryCache cache,
        string key,
        T value,
        TimeSpan timeout)
    {
        var options = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = timeout,
        };
        cache.Set(key, value, options);
    }
}