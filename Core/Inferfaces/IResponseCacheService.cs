using System;
using System.Threading.Tasks;

namespace Core.Inferfaces
{
    public interface IResponseCacheService
    {
        Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive);
        Task<string> GetCachedResponse(string cacheKey);
    }
}