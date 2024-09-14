using Microsoft.Extensions.Caching.Memory;

namespace ApiGateway.Caching;

public class MemoryCacheService(IMemoryCache memoryCache) : IMemoryCacheService
{

    public string GetCache(string key) => memoryCache.Get<string>(key)!;


    public void SetCache(string key, object value, int expirationInSeconds) => memoryCache.Set(key, value, DateTimeOffset.Now.AddSeconds(expirationInSeconds));
}
