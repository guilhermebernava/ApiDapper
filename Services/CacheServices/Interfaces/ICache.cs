namespace Services.CacheServices;

public interface ICache
{
   T? GetOrCreate<T>(string key, T? data = default);
}
