using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PontiApp.Images.Cache.Caching_service
{
    public class CachingService : ICachingService
    {
        private readonly IDistributedCache _cache;

        public CachingService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task SetRecordAsync<T>(string key, T data, TimeSpan absoluteTime, TimeSpan slidingTime)
        {
            var options = new DistributedCacheEntryOptions();
            options.AbsoluteExpirationRelativeToNow = absoluteTime;
            options.SlidingExpiration = slidingTime;
            var json = JsonSerializer.Serialize(data);
            await _cache.SetStringAsync(key, json, options);
        }

        public async Task<T> GetRecordAsync<T>(string key)
        {
            var json = await _cache.GetStringAsync(key);
            if (json == null)
            {
                return default(T);
            }
            return JsonSerializer.Deserialize<T>(json);
        }

        public async Task UpdateRecordAsync<T>(string key, T data, TimeSpan absoluteTime, TimeSpan slidingTime)
        {
            var options = new DistributedCacheEntryOptions();
            options.AbsoluteExpirationRelativeToNow = absoluteTime;
            options.SlidingExpiration = slidingTime;
            var json = JsonSerializer.Serialize(data);
            await _cache.RemoveAsync(key);
            await _cache.SetStringAsync(key, json, options);
        }
    }
}
