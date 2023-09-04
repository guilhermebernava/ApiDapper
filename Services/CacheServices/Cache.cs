using Microsoft.Extensions.Caching.Memory;

namespace Services.CacheServices;

public class Cache : ICache
{
    private readonly IMemoryCache _cache;

    public Cache(IMemoryCache cache)
    {
        _cache = cache;
    }

    public T? GetOrCreate<T>(string key, T? data = default)
    {
        var result =  _cache.Get<T>(key);

        if(result  == null && data != null)
        {
            _cache.Set<T>(key, data,TimeSpan.FromMinutes(30));
            return default;
        }

        return result;
    }
}
